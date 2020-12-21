namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.activities",
                c => new
                    {
                        activities_id = c.Int(nullable: false, identity: true),
                        student_id = c.Int(),
                        club_membership = c.Boolean(nullable: false),
                        club_name = c.String(),
                        designation = c.String(),
                        achievement = c.String(),
                        others_co_curricular_activities = c.Boolean(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.activities_id)
                .ForeignKey("dbo.students", t => t.student_id)
                .Index(t => t.student_id);
            
            CreateTable(
                "dbo.students",
                c => new
                    {
                        student_id = c.Int(nullable: false, identity: true),
                        session_id = c.Int(),
                        year_id = c.Int(),
                        Roll_No = c.Int(nullable: false),
                        quota = c.Boolean(nullable: false),
                        quata_description = c.String(),
                        skills = c.String(),
                        hobby = c.String(),
                        fathers_name = c.String(),
                        fathers_occupation = c.String(),
                        fathers_contact_no = c.String(),
                        mothers_name = c.String(),
                        mothers_occupation = c.String(),
                        mothers_contact_no = c.String(),
                        guardians_name = c.String(),
                        guardians_occupation = c.String(),
                        guardians_contact_no = c.String(),
                    })
                .PrimaryKey(t => t.student_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .Index(t => t.session_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.current_academic",
                c => new
                    {
                        currentacademic_id = c.Int(nullable: false, identity: true),
                        student_id = c.Int(),
                        session_id = c.Int(),
                        admission_date = c.DateTime(nullable: false),
                        dept = c.String(),
                        year_id = c.Int(),
                        result_id = c.Int(),
                    })
                .PrimaryKey(t => t.currentacademic_id)
                .ForeignKey("dbo.results", t => t.result_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .ForeignKey("dbo.students", t => t.student_id)
                .Index(t => t.student_id)
                .Index(t => t.session_id)
                .Index(t => t.year_id)
                .Index(t => t.result_id);
            
            CreateTable(
                "dbo.results",
                c => new
                    {
                        result_id = c.Int(nullable: false, identity: true),
                        Roll_No = c.Int(nullable: false),
                        student_id = c.Int(),
                        session_id = c.Int(),
                        year_id = c.Int(),
                        cgpa = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.result_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .ForeignKey("dbo.students", t => t.student_id)
                .Index(t => t.student_id)
                .Index(t => t.session_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        session_id = c.Int(nullable: false, identity: true),
                        session_name = c.String(),
                    })
                .PrimaryKey(t => t.session_id);
            
            CreateTable(
                "dbo.routines",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        routine_upload = c.String(),
                        class_date = c.DateTime(nullable: false),
                        day = c.String(),
                        teacher_id = c.Int(),
                        subject_id = c.Int(),
                        session_id = c.Int(),
                        start_time = c.Time(nullable: false, precision: 7),
                        end_time = c.Time(nullable: false, precision: 7),
                        duration = c.String(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.teachers", t => t.teacher_id)
                .Index(t => t.teacher_id)
                .Index(t => t.subject_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        subject_id = c.Int(nullable: false, identity: true),
                        Subject_Name = c.String(),
                        subject_code = c.String(),
                    })
                .PrimaryKey(t => t.subject_id);
            
            CreateTable(
                "dbo.books",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(),
                        book_author = c.String(),
                        specification = c.String(),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        year_id = c.Int(nullable: false, identity: true),
                        year_name = c.String(),
                        semester_name = c.String(),
                    })
                .PrimaryKey(t => t.year_id);
            
            CreateTable(
                "dbo.materials",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(),
                        arranged_by = c.String(),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.teachers",
                c => new
                    {
                        teacher_id = c.Int(nullable: false, identity: true),
                        teacher__name = c.String(),
                        designation = c.String(),
                        favorite_quote = c.String(),
                        work_area = c.String(),
                        achievement = c.String(),
                        publication = c.String(),
                        publication_links = c.String(),
                        website = c.String(),
                    })
                .PrimaryKey(t => t.teacher_id);
            
            CreateTable(
                "dbo.teacher_career",
                c => new
                    {
                        teachercareer_id = c.Int(nullable: false, identity: true),
                        teacher_id = c.Int(),
                        joining_date = c.DateTime(nullable: false),
                        phd_status = c.String(),
                        phd_institute = c.String(),
                        msc_status = c.String(),
                        msc_institute = c.String(),
                        msc_session = c.String(),
                        msc_result = c.Double(nullable: false),
                        bsc_status = c.String(),
                        bsc_institute = c.String(),
                        bsc_session = c.String(),
                        bsc_result = c.Double(nullable: false),
                        ex_workplaces = c.String(),
                    })
                .PrimaryKey(t => t.teachercareer_id)
                .ForeignKey("dbo.teachers", t => t.teacher_id)
                .Index(t => t.teacher_id);
            
            CreateTable(
                "dbo.previous_academic",
                c => new
                    {
                        previousacademic_id = c.Int(nullable: false, identity: true),
                        student_id = c.Int(),
                        hsc_roll = c.Int(nullable: false),
                        hsc_reg = c.Int(nullable: false),
                        hsc_result = c.Double(nullable: false),
                        hsc_board = c.String(),
                        hsc_college = c.String(),
                        hsc_section = c.String(),
                        ssc_roll = c.Int(nullable: false),
                        ssc_reg = c.Int(nullable: false),
                        ssc_result = c.Double(nullable: false),
                        ssc_board = c.String(),
                        ssc_school = c.String(),
                        ssc_section = c.String(),
                    })
                .PrimaryKey(t => t.previousacademic_id)
                .ForeignKey("dbo.students", t => t.student_id)
                .Index(t => t.student_id);
            
            CreateTable(
                "dbo.notices",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(),
                        notice_topic = c.String(),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(),
                        priority = c.String(),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.staff_career",
                c => new
                    {
                        staffcareer_id = c.Int(nullable: false, identity: true),
                        staff_id = c.Int(),
                        joining_date = c.DateTime(nullable: false),
                        diploma_result = c.Double(nullable: false),
                        diploma_institute = c.String(),
                        hsc_result = c.Double(nullable: false),
                        hsc_institute = c.String(),
                        ssc_result = c.Double(nullable: false),
                        ssc_institute = c.String(),
                    })
                .PrimaryKey(t => t.staffcareer_id)
                .ForeignKey("dbo.Staffs", t => t.staff_id)
                .Index(t => t.staff_id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        staff_id = c.Int(nullable: false, identity: true),
                        staff_name = c.String(),
                        favorite_quote = c.String(),
                        designation = c.String(),
                    })
                .PrimaryKey(t => t.staff_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.staff_career", "staff_id", "dbo.Staffs");
            DropForeignKey("dbo.previous_academic", "student_id", "dbo.students");
            DropForeignKey("dbo.current_academic", "student_id", "dbo.students");
            DropForeignKey("dbo.results", "student_id", "dbo.students");
            DropForeignKey("dbo.students", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.teacher_career", "teacher_id", "dbo.teachers");
            DropForeignKey("dbo.routines", "teacher_id", "dbo.teachers");
            DropForeignKey("dbo.routines", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.students", "year_id", "dbo.Years");
            DropForeignKey("dbo.results", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.current_academic", "year_id", "dbo.Years");
            DropForeignKey("dbo.books", "year_id", "dbo.Years");
            DropForeignKey("dbo.books", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.routines", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.results", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.current_academic", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.current_academic", "result_id", "dbo.results");
            DropForeignKey("dbo.activities", "student_id", "dbo.students");
            DropIndex("dbo.staff_career", new[] { "staff_id" });
            DropIndex("dbo.previous_academic", new[] { "student_id" });
            DropIndex("dbo.teacher_career", new[] { "teacher_id" });
            DropIndex("dbo.materials", new[] { "year_id" });
            DropIndex("dbo.materials", new[] { "subject_id" });
            DropIndex("dbo.books", new[] { "subject_id" });
            DropIndex("dbo.books", new[] { "year_id" });
            DropIndex("dbo.routines", new[] { "session_id" });
            DropIndex("dbo.routines", new[] { "subject_id" });
            DropIndex("dbo.routines", new[] { "teacher_id" });
            DropIndex("dbo.results", new[] { "year_id" });
            DropIndex("dbo.results", new[] { "session_id" });
            DropIndex("dbo.results", new[] { "student_id" });
            DropIndex("dbo.current_academic", new[] { "result_id" });
            DropIndex("dbo.current_academic", new[] { "year_id" });
            DropIndex("dbo.current_academic", new[] { "session_id" });
            DropIndex("dbo.current_academic", new[] { "student_id" });
            DropIndex("dbo.students", new[] { "year_id" });
            DropIndex("dbo.students", new[] { "session_id" });
            DropIndex("dbo.activities", new[] { "student_id" });
            DropTable("dbo.Staffs");
            DropTable("dbo.staff_career");
            DropTable("dbo.notices");
            DropTable("dbo.previous_academic");
            DropTable("dbo.teacher_career");
            DropTable("dbo.teachers");
            DropTable("dbo.materials");
            DropTable("dbo.Years");
            DropTable("dbo.books");
            DropTable("dbo.Subjects");
            DropTable("dbo.routines");
            DropTable("dbo.Sessions");
            DropTable("dbo.results");
            DropTable("dbo.current_academic");
            DropTable("dbo.students");
            DropTable("dbo.activities");
        }
    }
}
