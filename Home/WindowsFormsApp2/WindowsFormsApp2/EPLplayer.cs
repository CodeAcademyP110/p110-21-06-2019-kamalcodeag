//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class EPLplayer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public byte age { get; set; }
        public Nullable<int> positionId { get; set; }
        public Nullable<int> clubId { get; set; }
    
        public virtual EPLclub EPLclub { get; set; }
        public virtual EPLposition EPLposition { get; set; }
    }
}
