/*
 * UnRef.cs
 *
 *   Created: 2023-05-07-03:42:03
 *   Modified: 2023-05-07-03:42:03
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Runtime.InteropServices.JavaScript;

namespace Dgmjr.UnRef;

public static class UnRef
{
    public static async Task Main(string[] args)
    {
        try
        {
            if (args.Length > 0 && args.Length < 3)
            {
                string yamlOrJsonInputFile = args[0];
                var yamlOrJsonInputReader =
                    args.Length > 0 ? new StreamReader(yamlOrJsonInputFile) : In;
                var yamlOrJsonOutputFile = args.Length == 2 ? args[1] : null;
                var yamlOrJsonOutputWriter =
                    args.Length == 2 ? new StreamWriter(yamlOrJsonOutputFile) : Out;
                string? outputString;
                if (Path.GetExtension(yamlOrJsonInputFile) is ".yaml" or ".yml")
                {
                    outputString =
                        args.Length == 2
                        && (Path.GetExtension(yamlOrJsonOutputFile) is ".yaml" or ".yml")
                            ? yamlOrJsonInputReader.DeserializeYaml().UnRef().ToString()
                            : yamlOrJsonInputReader.DeserializeYaml().UnRef().ToJson().ToString();
                }
                else
                {
                    outputString =
                        args.Length == 2
                        && (Path.GetExtension(yamlOrJsonOutputFile) is ".yaml" or ".yml")
                            ? JDoc.Parse(await In.ReadToEndAsync()).UnRef().ToYaml().ToString()
                            : JDoc.Parse(await In.ReadToEndAsync()).UnRef().ToString();
                }
                await yamlOrJsonOutputWriter.WriteLineAsync(outputString);
            }
            else
            {
                WriteLine(
                    "Usage: UnRef <yaml-or-json-schema-file> <yaml-or-json-schema-output-file>"
                );
            }
        }
        catch (Exception e)
        {
            WriteLine(e.Message + "\n" + e.StackTrace);
        }
    }
}
