using Microsoft.EntityFrameworkCore.Migrations;
using Stefanini.ViaReport.DataStorage.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage.Migrations
{
    public class MigrationTests
    {
        [Fact(DisplayName ="[] Deve")]
        public void Deve()
        {
            var migrationBuilder = new MigrationBuilder("Microsoft.EntityFrameworkCore.InMemory");

            //var initialCreate = new InitialCreate();
           
            //var configuration = new Migrations();
        }
    }
}
