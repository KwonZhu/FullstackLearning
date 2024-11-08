﻿namespace Practice5.Filters
{
    public class PermissionCodeAttribute : Attribute
    {
        public string Code { get; set; }
        public PermissionCodeAttribute(string code)
        {
            this.Code = code;
        }
    }
}
