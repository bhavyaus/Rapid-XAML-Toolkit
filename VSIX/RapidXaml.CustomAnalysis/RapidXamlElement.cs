﻿// Copyright (c) Matt Lacey Ltd. All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;

namespace RapidXaml
{
    public class RapidXamlElement
    {
        public string Name { get; internal set; } = string.Empty;

        public string Content { get; internal set; } = string.Empty;

        public List<RapidXamlAttribute> Attributes { get; internal set; } = new List<RapidXamlAttribute>();

        public List<RapidXamlElement> Children { get; internal set; } = new List<RapidXamlElement>();

        public static RapidXamlElement Build(string name)
        {
            return new RapidXamlElement { Name = name };
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Attributes.Count} attributes, {this.Children.Count} children)";
        }

        // Utility methods to simplify usage
        public bool ContainsAttribute(string attributeName)
        {
            return this.Attributes.Any(
                a => a.Name.Equals(attributeName, StringComparison.InvariantCultureIgnoreCase));
        }

        public bool ContainsChild(string childName)
        {
            return this.Children.Any(
                a => a.Name.Equals(childName, StringComparison.InvariantCultureIgnoreCase)
                  || a.Name.EndsWith($":{childName}", StringComparison.InvariantCultureIgnoreCase));
        }

        public bool ContainsDescendant(string childName)
        {
            if (this.ContainsChild(childName))
            {
                return true;
            }

            foreach (var child in this.Children)
            {
                if (child.ContainsDescendant(childName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
