/*
 * ModelMediaTypeNames.cs
 *
 *   Created: 2023-03-18-07:34:31
 *   Modified: 2023-03-18-07:34:31
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime;

public static class ModelMediaTypeNames
{
    public const string Any = "*/*";
    public const string Base = "model";
    public const string Example = "model/example";

    /// <see href="https://www.iana.org/assignments/media-types/model/3mf">[http://www.3mf.io/specification][_3MF][Michael_Sweet]</see>
    /// <value>model/3mf</value>
    /// <summary> The model/3mf MIME type</summary>
    public const string _3mf = Base + "/3mf";

    /// <see href="https://www.iana.org/assignments/media-types/model/e57">[ASTM]</see>
    /// <value>model/e57</value>
    /// <summary> The model/e57 MIME type</summary>
    public const string e57 = Base + "/e57";

    /// <see href="https://www.iana.org/assignments/media-types/model/example">[RFC4735]</see>
    /// <value>model/example</value>
    /// <summary> The model/example MIME type</summary>
    public const string example = Base + "/example";

    /// <see href="https://www.iana.org/assignments/media-types/model/gltf-binary">[Khronos][Saurabh_Bhatia]</see>
    /// <value>model/gltf-binary</value>
    /// <summary> The model/gltf-binary MIME type</summary>
    public const string gltf_binary = Base + "/gltf-binary";

    /// <see href="https://www.iana.org/assignments/media-types/model/gltf+json">[Khronos][Uli_Klumpp]</see>
    /// <value>model/gltf+json</value>
    /// <summary> The model/gltf+json MIME type</summary>
    public const string gltf_json = Base + "/gltf+json";

    /// <see href="https://www.iana.org/assignments/media-types/model/JT">[ISO-TC_184-SC_4][Michael_Zink]</see>
    /// <value>model/JT</value>
    /// <summary> The model/JT MIME type</summary>
    public const string JT = Base + "/JT";

    /// <see href="https://www.iana.org/assignments/media-types/model/iges">[Curtis_Parks]</see>
    /// <value>model/iges</value>
    /// <summary> The model/iges MIME type</summary>
    public const string iges = Base + "/iges";

    /// <see href=">[RFC2077]</see>
    /// <value></value>
    /// <summary> The  MIME type</summary>
    public const string mesh = Base + "/mesh";

    /// <see href="https://www.iana.org/assignments/media-types/model/mtl">[DICOM_Standard_Committee][DICOM_WG_17][Carolyn_Hull]</see>
    /// <value>model/mtl</value>
    /// <summary> The model/mtl MIME type</summary>
    public const string mtl = Base + "/mtl";

    /// <see href="https://www.iana.org/assignments/media-types/model/obj">[DICOM_Standard_Committee][DICOM_WG_17][Carolyn_Hull]</see>
    /// <value>model/obj</value>
    /// <summary> The model/obj MIME type</summary>
    public const string obj = Base + "/obj";

    /// <see href="https://www.iana.org/assignments/media-types/model/prc">[ISO-TC_171-SC_2][Betsy_Fanning]</see>
    /// <value>model/prc</value>
    /// <summary> The model/prc MIME type</summary>
    public const string prc = Base + "/prc";

    /// <see href="https://www.iana.org/assignments/media-types/model/step">[ISO-TC_184-SC_4][Dana_Tripp]</see>
    /// <value>model/step</value>
    /// <summary> The model/step MIME type</summary>
    public const string step = Base + "/step";

    /// <see href="https://www.iana.org/assignments/media-types/model/step+xml">[ISO-TC_184-SC_4][Dana_Tripp]</see>
    /// <value>model/step+xml</value>
    /// <summary> The model/step+xml MIME type</summary>
    public const string step_xml = Base + "/step+xml";

    /// <see href="https://www.iana.org/assignments/media-types/model/step+zip">[ISO-TC_184-SC_4][Dana_Tripp]</see>
    /// <value>model/step+zip</value>
    /// <summary> The model/step+zip MIME type</summary>
    public const string step_zip = Base + "/step+zip";

    /// <see href="https://www.iana.org/assignments/media-types/model/step-xml+zip">[ISO-TC_184-SC_4][Dana_Tripp]</see>
    /// <value>model/step-xml+zip</value>
    /// <summary> The model/step-xml+zip MIME type</summary>
    public const string step_xml_zip = Base + "/step-xml+zip";

    /// <see href="https://www.iana.org/assignments/media-types/model/stl">[DICOM_Standard_Committee][DICOM_WG_17][Carolyn_Hull]</see>
    /// <value>model/stl</value>
    /// <summary> The model/stl MIME type</summary>
    public const string stl = Base + "/stl";

    /// <see href="https://www.iana.org/assignments/media-types/model/u3d">[PDF_Association][Peter_Wyatt]</see>
    /// <value>model/u3d</value>
    /// <summary> The model/u3d MIME type</summary>
    public const string u3d = Base + "/u3d";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.cld">[Robert_Monaghan]</see>
    /// <value>model/vnd.cld</value>
    /// <summary> The model/vnd.cld MIME type</summary>
    public const string vnd_cld = Base + "/vnd.cld";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.collada+xml">[James_Riordon]</see>
    /// <value>model/vnd.collada+xml</value>
    /// <summary> The model/vnd.collada+xml MIME type</summary>
    public const string vnd_collada_xml = Base + "/vnd.collada+xml";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.dwf">[Jason_Pratt]</see>
    /// <value>model/vnd.dwf</value>
    /// <summary> The model/vnd.dwf MIME type</summary>
    public const string vnd_dwf = Base + "/vnd.dwf";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.flatland.3dml">[Michael_Powers]</see>
    /// <value>model/vnd.flatland.3dml</value>
    /// <summary> The model/vnd.flatland.3dml MIME type</summary>
    public const string vnd_flatland_3dml = Base + "/vnd.flatland.3dml";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.gdl">[Attila_Babits]</see>
    /// <value>model/vnd.gdl</value>
    /// <summary> The model/vnd.gdl MIME type</summary>
    public const string vnd_gdl = Base + "/vnd.gdl";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.gs-gdl">[Attila_Babits]</see>
    /// <value>model/vnd.gs-gdl</value>
    /// <summary> The model/vnd.gs-gdl MIME type</summary>
    public const string vnd_gs_gdl = Base + "/vnd.gs-gdl";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.gtw">[Yutaka_Ozaki]</see>
    /// <value>model/vnd.gtw</value>
    /// <summary> The model/vnd.gtw MIME type</summary>
    public const string vnd_gtw = Base + "/vnd.gtw";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.moml+xml">[Christopher_Brooks]</see>
    /// <value>model/vnd.moml+xml</value>
    /// <summary> The model/vnd.moml+xml MIME type</summary>
    public const string vnd_moml_xml = Base + "/vnd.moml+xml";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.mts">[Boris_Rabinovitch]</see>
    /// <value>model/vnd.mts</value>
    /// <summary> The model/vnd.mts MIME type</summary>
    public const string vnd_mts = Base + "/vnd.mts";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.opengex">[Eric_Lengyel]</see>
    /// <value>model/vnd.opengex</value>
    /// <summary> The model/vnd.opengex MIME type</summary>
    public const string vnd_opengex = Base + "/vnd.opengex";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.parasolid.transmit.binary">[Parasolid]</see>
    /// <value>model/vnd.parasolid.transmit.binary</value>
    /// <summary> The model/vnd.parasolid.transmit.binary MIME type</summary>
    public const string vnd_parasolid_transmit_binary =
        Base + "/vnd.parasolid.transmit.binary";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.parasolid.transmit.text">[Parasolid]</see>
    /// <value>model/vnd.parasolid.transmit.text</value>
    /// <summary> The model/vnd.parasolid.transmit.text MIME type</summary>
    public const string vnd_parasolid_transmit_text = Base + "/vnd.parasolid.transmit.text";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.pytha.pyox">[Daniel_Flassig]</see>
    /// <value>model/vnd.pytha.pyox</value>
    /// <summary> The model/vnd.pytha.pyox MIME type</summary>
    public const string vnd_pytha_pyox = Base + "/vnd.pytha.pyox";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.rosette.annotated-data-model">[Benson_Margulies]</see>
    /// <value>model/vnd.rosette.annotated-data-model</value>
    /// <summary> The model/vnd.rosette.annotated-data-model MIME type</summary>
    public const string vnd_rosette_annotated_data_model =
        Base + "/vnd.rosette.annotated-data-model";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.sap.vds">[SAP_SE][Igor_Afanasyev]</see>
    /// <value>model/vnd.sap.vds</value>
    /// <summary> The model/vnd.sap.vds MIME type</summary>
    public const string vnd_sap_vds = Base + "/vnd.sap.vds";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.usda">[Sebastian_Grassia]</see>
    /// <value>model/vnd.usda</value>
    /// <summary> The model/vnd.usda MIME type</summary>
    public const string vnd_usda = Base + "/vnd.usda";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.usdz+zip">[Sebastian_Grassia]</see>
    /// <value>model/vnd.usdz+zip</value>
    /// <summary> The model/vnd.usdz+zip MIME type</summary>
    public const string vnd_usdz_zip = Base + "/vnd.usdz+zip";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.valve.source.compiled-map">[Henrik_Andersson]</see>
    /// <value>model/vnd.valve.source.compiled-map</value>
    /// <summary> The model/vnd.valve.source.compiled-map MIME type</summary>
    public const string vnd_valve_source_compiled_map =
        Base + "/vnd.valve.source.compiled-map";

    /// <see href="https://www.iana.org/assignments/media-types/model/vnd.vtu">[Boris_Rabinovitch]</see>
    /// <value>model/vnd.vtu</value>
    /// <summary> The model/vnd.vtu MIME type</summary>
    public const string vnd_vtu = Base + "/vnd.vtu";

    /// <see href=">[RFC2077]</see>
    /// <value></value>
    /// <summary> The  MIME type</summary>
    public const string vrml = Base + "/vrml";

    /// <see href="https://www.iana.org/assignments/media-types/model/x3d-vrml">[Web3D][Web3D_X3D]</see>
    /// <value>model/x3d-vrml</value>
    /// <summary> The model/x3d-vrml MIME type</summary>
    public const string x3d_vrml = Base + "/x3d_vrml";

    /// <see href="https://www.iana.org/assignments/media-types/model/x3d+fastinfoset">[Web3D_X3D]</see>
    /// <value>model/x3d+fastinfoset</value>
    /// <summary> The model/x3d+fastinfoset MIME type</summary>
    public const string x3d_fastinfoset = Base + "/x3d_fastinfoset";

    /// <see href="https://www.iana.org/assignments/media-types/model/x3d+xml">[Web3D][Web3D_X3D]</see>
    /// <value>model/x3d+xml</value>
    /// <summary> The model/x3d+xml MIME type</summary>
    public const string x3d_xml = Base + "/x3d_xml";
}
