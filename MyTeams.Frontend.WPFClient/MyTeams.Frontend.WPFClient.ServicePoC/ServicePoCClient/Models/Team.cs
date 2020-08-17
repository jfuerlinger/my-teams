﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace MyTeams.Frontend.ServicePoC.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class Team
    {
        /// <summary>
        /// Initializes a new instance of the Team class.
        /// </summary>
        public Team() { }

        /// <summary>
        /// Initializes a new instance of the Team class.
        /// </summary>
        public Team(string displayName, IList<Channel> channels = default(IList<Channel>), int? id = default(int?), byte[] rowVersion = default(byte[]))
        {
            DisplayName = displayName;
            Channels = channels;
            Id = id;
            RowVersion = rowVersion;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "channels")]
        public IList<Channel> Channels { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rowVersion")]
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (DisplayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DisplayName");
            }
            if (this.DisplayName != null)
            {
                if (this.DisplayName.Length < 5)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DisplayName", 5);
                }
            }
            if (this.Channels != null)
            {
                foreach (var element in this.Channels)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
