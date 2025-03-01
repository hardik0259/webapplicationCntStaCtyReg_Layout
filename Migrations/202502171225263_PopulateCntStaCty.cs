namespace webapplicationCntStaCtyReg_Layout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCntStaCty : DbMigration
    {
        public override void Up()
        {
            //Country
            Sql("insert Countries values('India')");//1
            Sql("insert Countries values('US')");//2
            Sql("insert Countries values('UK')");//3
            //STATE
            Sql("insert States values('Punjab',1)");//1
            Sql("insert States values('HP',1)");//2
            Sql("insert States values('UP',1)");//3
            Sql("insert States values('ABC',2)");//4
            Sql("insert States values('XYZ',2)");//5
            Sql("insert States values('ASD',2)");//6
            //City
            Sql("insert Cities values('Mohali',1)");//1
            Sql("insert Cities values('LDH',1)");//2
            Sql("insert Cities values('ASR',1)");//3
            Sql("insert Cities values('Shimla',2)");//4
            Sql("insert Cities values('Kangra',2)");//5
            Sql("insert Cities values('Una',2)");//6

        }
        
        public override void Down()
        {
        }
    }
}
