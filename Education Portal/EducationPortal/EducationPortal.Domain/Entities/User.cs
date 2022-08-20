﻿namespace EducationPortal.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
