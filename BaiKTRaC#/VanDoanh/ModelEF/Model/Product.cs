namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(50)]
        [Display(Name = "ID")]
        public string ProductID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Giá")]
        public string UnitCost { get; set; }

        [Display(Name = "Số Lượng")]
        public int? Quantity { get; set; }


        [Display(Name = "Hình Ảnh")]
        public byte[] Image { get; set; }

        [StringLength(50)]
        [Display(Name = "Miêu Tả")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại SP_ID")]
        public string CategoryID { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng Thái")]
        public string Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
