//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketP
{
    using System;
    using System.Collections.Generic;
    
    public partial class products
    {
        public int idProducts { get; set; }
        public string nameProducts { get; set; }
        public string customer { get; set; }
        public int quantity { get; set; }
        public Nullable<System.DateTime> expiration { get; set; }
        public double price { get; set; }
        public Nullable<double> sale { get; set; }
        public string barcode { get; set; }
    }
}