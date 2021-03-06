// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Reflection.Metadata.Tests
{
    internal struct MethodImportRow
    {
        public readonly MethodImport Import;
        public readonly MethodDefinitionHandle Parent;

        public MethodImportRow(MethodImport import, MethodDefinitionHandle parent)
        {
            Import = import;
            Parent = parent;
        }
    }
}
