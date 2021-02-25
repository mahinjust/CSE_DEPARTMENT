namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.activities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.activities", "club_name", c => c.String(nullable: false));
            AlterColumn("dbo.activities", "designation", c => c.String(nullable: false));
            AlterColumn("dbo.students", "fathers_name", c => c.String(nullable: false));
            AlterColumn("dbo.students", "fathers_occupation", c => c.String(nullable: false));
            AlterColumn("dbo.students", "fathers_contact_no", c => c.String(nullable: false));
            AlterColumn("dbo.students", "mothers_name", c => c.String(nullable: false));
            AlterColumn("dbo.students", "mothers_occupation", c => c.String(nullable: false));
            AlterColumn("dbo.students", "mothers_contact_no", c => c.String(nullable: false));
            AlterColumn("dbo.students", "guardians_name", c => c.String(nullable: false));
            AlterColumn("dbo.students", "guardians_occupation", c => c.String(nullable: false));
            AlterColumn("dbo.students", "guardians_contact_no", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "staff_name", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "designation", c => c.String(nullable: false));
            AlterColumn("dbo.teachers", "teacher_name", c => c.String(nullable: false));
            AlterColumn("dbo.teachers", "designation", c => c.String(nullable: false));
            AlterColumn("dbo.teachers", "work_area", c => c.String(nullable: false));
            AlterColumn("dbo.routines", "day", c => c.String(nullable: false));
            AlterColumn("dbo.routines", "duration", c => c.String(nullable: false));
            AlterColumn("dbo.Sessions", "session_name", c => c.String(nullable: false));
            AlterColumn("dbo.current_academic", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.current_academic", "dept", c => c.String(nullable: false));
            AlterColumn("dbo.results", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Years", "year_name", c => c.String(nullable: false));
            AlterColumn("dbo.books", "book_name", c => c.String(nullable: false));
            AlterColumn("dbo.books", "book_author", c => c.String(nullable: false));
            AlterColumn("dbo.books", "specification", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "Subject_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "subject_code", c => c.String(nullable: false));
            AlterColumn("dbo.materials", "materials_topic", c => c.String(nullable: false));
            AlterColumn("dbo.materials", "arranged_by", c => c.String(nullable: false));
            AlterColumn("dbo.teacher_career", "phd_status", c => c.String(nullable: false));
            AlterColumn("dbo.teacher_career", "bsc_status", c => c.String(nullable: false));
            AlterColumn("dbo.teacher_career", "bsc_institute", c => c.String(nullable: false));
            AlterColumn("dbo.teacher_career", "bsc_session", c => c.String(nullable: false));
            AlterColumn("dbo.previous_academic", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.previous_academic", "hsc_board", c => c.String(nullable: false));
            AlterColumn("dbo.previous_academic", "hsc_college", c => c.String(nullable: false));
            AlterColumn("dbo.previous_academic", "hsc_section", c => c.String(nullable: false));
            AlterColumn("dbo.previous_academic", "ssc_board", c => c.String(nullable: false));
            AlterColumn("dbo.previous_academic", "ssc_school", c => c.String(nullable: false));
            AlterColumn("dbo.previous_academic", "ssc_section", c => c.String(nullable: false));
            AlterColumn("dbo.notices", "notice_upload", c => c.String(nullable: false));
            AlterColumn("dbo.notices", "notice_topic", c => c.String(nullable: false));
            AlterColumn("dbo.notices", "created_by", c => c.String(nullable: false));
            AlterColumn("dbo.notices", "deadline", c => c.String(nullable: false));
            AlterColumn("dbo.notices", "priority", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.notices", "priority", c => c.String());
            AlterColumn("dbo.notices", "deadline", c => c.String());
            AlterColumn("dbo.notices", "created_by", c => c.String());
            AlterColumn("dbo.notices", "notice_topic", c => c.String());
            AlterColumn("dbo.notices", "notice_upload", c => c.String());
            AlterColumn("dbo.previous_academic", "ssc_section", c => c.String());
            AlterColumn("dbo.previous_academic", "ssc_school", c => c.String());
            AlterColumn("dbo.previous_academic", "ssc_board", c => c.String());
            AlterColumn("dbo.previous_academic", "hsc_section", c => c.String());
            AlterColumn("dbo.previous_academic", "hsc_college", c => c.String());
            AlterColumn("dbo.previous_academic", "hsc_board", c => c.String());
            AlterColumn("dbo.previous_academic", "Name", c => c.String());
            AlterColumn("dbo.teacher_career", "bsc_session", c => c.String());
            AlterColumn("dbo.teacher_career", "bsc_institute", c => c.String());
            AlterColumn("dbo.teacher_career", "bsc_status", c => c.String());
            AlterColumn("dbo.teacher_career", "phd_status", c => c.String());
            AlterColumn("dbo.materials", "arranged_by", c => c.String());
            AlterColumn("dbo.materials", "materials_topic", c => c.String());
            AlterColumn("dbo.Subjects", "subject_code", c => c.String());
            AlterColumn("dbo.Subjects", "Subject_Name", c => c.String());
            AlterColumn("dbo.books", "specification", c => c.String());
            AlterColumn("dbo.books", "book_author", c => c.String());
            AlterColumn("dbo.books", "book_name", c => c.String());
            AlterColumn("dbo.Years", "year_name", c => c.String());
            AlterColumn("dbo.results", "Name", c => c.String());
            AlterColumn("dbo.current_academic", "dept", c => c.String());
            AlterColumn("dbo.current_academic", "Name", c => c.String());
            AlterColumn("dbo.Sessions", "session_name", c => c.String());
            AlterColumn("dbo.routines", "duration", c => c.String());
            AlterColumn("dbo.routines", "day", c => c.String());
            AlterColumn("dbo.teachers", "work_area", c => c.String());
            AlterColumn("dbo.teachers", "designation", c => c.String());
            AlterColumn("dbo.teachers", "teacher_name", c => c.String());
            AlterColumn("dbo.Staffs", "designation", c => c.String());
            AlterColumn("dbo.Staffs", "staff_name", c => c.String());
            AlterColumn("dbo.students", "guardians_contact_no", c => c.String());
            AlterColumn("dbo.students", "guardians_occupation", c => c.String());
            AlterColumn("dbo.students", "guardians_name", c => c.String());
            AlterColumn("dbo.students", "mothers_contact_no", c => c.String());
            AlterColumn("dbo.students", "mothers_occupation", c => c.String());
            AlterColumn("dbo.students", "mothers_name", c => c.String());
            AlterColumn("dbo.students", "fathers_contact_no", c => c.String());
            AlterColumn("dbo.students", "fathers_occupation", c => c.String());
            AlterColumn("dbo.students", "fathers_name", c => c.String());
            AlterColumn("dbo.activities", "designation", c => c.String());
            AlterColumn("dbo.activities", "club_name", c => c.String());
            AlterColumn("dbo.activities", "Name", c => c.String());
        }
    }
}
