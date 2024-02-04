import { DotNet } from '@microsoft/dotnet-js-interop';
export const JSInterop = {
  invokeDotNetMethod: (method: string, ...args: any[]) => {
    return DotNet.invokeMethodAsync('BlazorApp', method, ...args);
  }
}
