﻿using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace Pixel.Attendance.Tests.General
{
    // ReSharper disable once InconsistentNaming
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=Attendance; Trusted_Connection=True;");
            csb["Database"].ShouldBe("Attendance");
        }
    }
}
