using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreModel.Model
{
    public partial class ErpMedical : DbContext
    {
        public ErpMedical()
        {
        }

        public ErpMedical(DbContextOptions<ErpMedical> options)
            : base(options)
        {
        }

        public virtual DbSet<Base> Base { get; set; }
        public virtual DbSet<CompanyBranch> CompanyBranch { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DoctorDetails> DoctorDetails { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseItem> PurchaseItem { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VendorCompany> VendorCompany { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=162.250.188.63;port=3306;database=souravdb;user=sourav;password=8777544879", x => x.ServerVersion("5.5.65-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Base>(entity =>
            {
                entity.ToTable("base");

                entity.HasComment("for base table for tracking user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnName("updatedBy")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updatedDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<CompanyBranch>(entity =>
            {
                entity.ToTable("companyBranch");

                entity.HasIndex(e => e.Baseid)
                    .HasName("baseid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Baseid)
                    .HasColumnName("baseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasColumnName("stateCode")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.CompanyBranch)
                    .HasForeignKey(d => d.Baseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("companyBranch_ibfk_1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Baseid)
                    .HasName("baseid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Baseid)
                    .HasColumnName("baseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DlNo)
                    .IsRequired()
                    .HasColumnName("dlNo")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("emailId")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.GstnCn)
                    .IsRequired()
                    .HasColumnName("gstnCN")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.MedicalCenter)
                    .IsRequired()
                    .HasColumnName("medicalCenter")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("mobileNo")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShippedAdress)
                    .IsRequired()
                    .HasColumnName("shippedAdress")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasColumnName("stateCode")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Station)
                    .IsRequired()
                    .HasColumnName("station")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.VehicelNo)
                    .IsRequired()
                    .HasColumnName("vehicelNo")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Baseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_ibfk_1");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<DoctorDetails>(entity =>
            {
                entity.ToTable("doctorDetails");

                entity.HasIndex(e => e.Baseid)
                    .HasName("baseid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Baseid)
                    .HasColumnName("baseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("emailId")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("mobileNo")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.DoctorDetails)
                    .HasForeignKey(d => d.Baseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctorDetails_ibfk_1");
            });

            modelBuilder.Entity<EmployeeMaster>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PRIMARY");

                entity.ToTable("employee_master");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contact_no")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Designation)
                    .HasColumnName("designation")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EmpName)
                    .HasColumnName("emp_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EnlistDate)
                    .HasColumnName("enlist_date")
                    .HasColumnType("date");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("date");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Baseid)
                    .HasName("baseid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Baseid)
                    .HasColumnName("baseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Mrp)
                    .HasColumnName("mrp")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Package)
                    .HasColumnName("package")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnName("productDescription")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.TaxValue)
                    .HasColumnName("taxValue")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Baseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_ibfk_1");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchase");

                entity.HasIndex(e => e.Baseid)
                    .HasName("baseid");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("customerId");

                entity.HasIndex(e => e.VendorId)
                    .HasName("vendorId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Baseid)
                    .HasColumnName("baseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("doctorId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GrRnNo)
                    .IsRequired()
                    .HasColumnName("grRnNo")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoiceDate")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasColumnName("invoiceNo")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Naration)
                    .IsRequired()
                    .HasColumnName("naration")
                    .HasColumnType("varchar(330)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PlaceOfSupply)
                    .IsRequired()
                    .HasColumnName("placeOfSupply")
                    .HasColumnType("varchar(130)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ReserveCharge)
                    .HasColumnName("reserveCharge")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.SlNo)
                    .HasColumnName("slNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.TransportCharge)
                    .HasColumnName("transportCharge")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.VendorId)
                    .HasColumnName("vendorId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PurchaseItem>(entity =>
            {
                entity.ToTable("purchaseItem");

                entity.HasIndex(e => e.Baseid)
                    .HasName("baseid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Baseid)
                    .HasColumnName("baseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.CgstPercentage)
                    .HasColumnName("cgstPercentage")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Hsn)
                    .IsRequired()
                    .HasColumnName("hsn")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.IgstPercentage)
                    .HasColumnName("igstPercentage")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Mrp)
                    .HasColumnName("mrp")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Package)
                    .IsRequired()
                    .HasColumnName("package")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.SgstPercentage)
                    .HasColumnName("sgstPercentage")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.TaxValue)
                    .HasColumnName("taxValue")
                    .HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.PurchaseItem)
                    .HasForeignKey(d => d.Baseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("purchaseItem_ibfk_1");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.HasIndex(e => e.Baseid)
                    .HasName("baseid");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("companyId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdhaarCard)
                    .IsRequired()
                    .HasColumnName("adhaarCard")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Baseid)
                    .HasColumnName("baseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("companyId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CurrentAddress)
                    .IsRequired()
                    .HasColumnName("currentAddress")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DlNo)
                    .IsRequired()
                    .HasColumnName("dlNo")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.GstNo)
                    .IsRequired()
                    .HasColumnName("gstNo")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.GstnCn)
                    .IsRequired()
                    .HasColumnName("gstnCN")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.MedicalCenter)
                    .IsRequired()
                    .HasColumnName("medicalCenter")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnName("mobileNo")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PanCard)
                    .IsRequired()
                    .HasColumnName("panCard")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PerAddress)
                    .IsRequired()
                    .HasColumnName("perAddress")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Station)
                    .IsRequired()
                    .HasColumnName("station")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.VehicalNo)
                    .IsRequired()
                    .HasColumnName("vehicalNo")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<VendorCompany>(entity =>
            {
                entity.ToTable("vendorCompany");

                entity.HasIndex(e => e.Baseid)
                    .HasName("baseid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Baseid)
                    .HasColumnName("baseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IsOutSider)
                    .HasColumnName("isOutSider")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasColumnName("stateCode")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.VendorCompany)
                    .HasForeignKey(d => d.Baseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vendorCompany_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
