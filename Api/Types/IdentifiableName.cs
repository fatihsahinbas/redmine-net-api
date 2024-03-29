﻿/*
   Copyright 2011 - 2014 Adrian Popescu, Dorin Huzum.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Redmine.Net.Api.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentifiableName : Identifiable<IdentifiableName>, IXmlSerializable, IEquatable<IdentifiableName>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifiableName"/> class.
        /// </summary>
        public IdentifiableName()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifiableName"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public IdentifiableName(XmlReader reader)
        {
            ReadXml(reader);
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlAttribute("name")]
        public String Name { get; set; }

        public XmlSchema GetSchema() { return null; }

        public virtual void ReadXml(XmlReader reader)
        {
            Id = Convert.ToInt32(reader.GetAttribute("id"));
            Name = reader.GetAttribute("name");
            reader.Read();
        }

        public virtual void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("id", Id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("name", Name);
        }

        public override string ToString()
        {
            return Id + ", " + Name;
        }

        public bool Equals(IdentifiableName other)
        {
            if (other == null) return false;
            return (Id == other.Id && Name == other.Name);
        }
    }
}