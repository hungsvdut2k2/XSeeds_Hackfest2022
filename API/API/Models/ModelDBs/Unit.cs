﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models.ModelDBs
{
    public class Unit
    {
        [Key]
        public int Unit_Id { get; set; }
        public int Course_Id { get; set; }
        public int Star { get; set; }
        public string Type { get; set;}
        public int Number { get; set; }
        [ForeignKey("Teacher")]
        public int Teacher_Id { get; set; }
        
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<GrammarUnit> GrammarUnits { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<VideoUnit> VideoUnits {get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<WordUnit> WordUnits { get; set; }

        public virtual ICollection<UnitComment> UnitComments { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<StudentsUnits> StudentsUnits { get; set; }

    }
}
