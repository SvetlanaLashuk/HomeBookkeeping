//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class outlayitem
    {   
        public int idItem { get; set; }
        public string itemName { get; set; }
        public string outlayComment { get; set; }

        public virtual ICollection<outlay> outlays { get; set; }

        public outlayitem()
        {
            outlays = new List<outlay>();
        }

        public override string ToString()
        {
            return itemName;
        }

    }
}