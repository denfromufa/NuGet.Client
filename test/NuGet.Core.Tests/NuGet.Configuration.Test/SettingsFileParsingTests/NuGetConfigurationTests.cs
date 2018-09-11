// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Xml.Linq;
using FluentAssertions;
using Xunit;

namespace NuGet.Configuration.Test
{
    public class NuGetConfigurationTests
    {
        [Fact]
        public void AsXNode_ReturnsExpectedXNode()
        {
            var configuration = new NuGetConfiguration(
                new AbstractSettingSection("Section",
                    new AddItem("key0", "value0")));

            var expectedXNode = new XElement("configuration",
                new XElement("Section",
                    new XElement("add",
                        new XAttribute("key", "key0"),
                        new XAttribute("value", "value0"))));

            var xNode = configuration.AsXNode();

            XNode.DeepEquals(xNode, expectedXNode).Should().BeTrue();
        }
    }
}
