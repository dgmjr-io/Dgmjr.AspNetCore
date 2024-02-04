"use strict";
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
exports.__esModule = true;
exports.JSInterop = void 0;
var dotnet_js_interop_1 = require("@microsoft/dotnet-js-interop");
exports.JSInterop = {
    invokeDotNetMethod: function (method) {
        var args = [];
        for (var _i = 1; _i < arguments.length; _i++) {
            args[_i - 1] = arguments[_i];
        }
        return dotnet_js_interop_1.DotNet.invokeMethodAsync.apply(dotnet_js_interop_1.DotNet, __spreadArray(['BlazorApp', method], args, false));
    }
};
