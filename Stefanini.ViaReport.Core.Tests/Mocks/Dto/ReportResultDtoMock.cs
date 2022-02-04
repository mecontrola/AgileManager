using Stefanini.ViaReport.Core.Data.Dto.EasyBI;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class ReportResultDtoMock
    {
        public static ReportResultDto GetDiv0()
            => new()
            {
                ReportName = "CFD - Colunas por Semana",
                QueryResults = new ReportResultQueryDto
                {
                    ColumnPositions = new List<List<ReportResultColumnPositionDto>>
                    {
                        new List<ReportResultColumnPositionDto>
                        {
                            new ReportResultColumnPositionDto
                            {
                                Name = "Issue history",
                                FullName = "[Measures].[Issue history]",
                                Depth = 0,
                                FormatString = "#,##0",
                                Calculated = true,
                                Span = 3
                            },
                            new ReportResultColumnPositionDto
                            {
                                Name = "Done",
                                FullName = "[Transition Status.Category].[Done]",
                                Drillable = true,
                                Depth = 1
                            }
                        },
                        new List<ReportResultColumnPositionDto>
                        {
                            new ReportResultColumnPositionDto
                            {
                                Name = "Issue history",
                                FullName = "[Measures].[Issue history]",
                                Depth = 0,
                                FormatString = "#,##0",
                                Calculated = true,
                                Span = 3
                            },
                            new ReportResultColumnPositionDto
                            {
                                Name = "In Progress",
                                FullName = "[Transition Status.Category].[In Progress]",
                                Drillable = true,
                                Depth = 1
                            }
                        },
                        new List<ReportResultColumnPositionDto>
                        {
                            new ReportResultColumnPositionDto
                            {
                                 Name = "Issue history",
                                 FullName = "[Measures].[Issue history]",
                                 Depth = 0,
                                 FormatString = "#,##0",
                                 Calculated = true,
                                 Span = 3
                            },
                            new ReportResultColumnPositionDto
                            {
                                Name = "To Do",
                                FullName = "[Transition Status.Category].[To Do]",
                                Drillable = true,
                                Depth = 1
                            }
                        }
                    },
                    RowPositions = new List<List<ReportResultRowPositionDto>>
                    {
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W01, Jan 04 2021", FullName = "[Time.Weekly].[2021].[W01, Jan 04 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-01-04") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W02, Jan 11 2021", FullName = "[Time.Weekly].[2021].[W02, Jan 11 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-01-11") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W03, Jan 18 2021", FullName = "[Time.Weekly].[2021].[W03, Jan 18 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-01-18") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W04, Jan 25 2021", FullName = "[Time.Weekly].[2021].[W04, Jan 25 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-01-25") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W05, Feb 01 2021", FullName = "[Time.Weekly].[2021].[W05, Feb 01 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-02-01") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W06, Feb 08 2021", FullName = "[Time.Weekly].[2021].[W06, Feb 08 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-02-08") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W07, Feb 15 2021", FullName = "[Time.Weekly].[2021].[W07, Feb 15 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-02-15") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W08, Feb 22 2021", FullName = "[Time.Weekly].[2021].[W08, Feb 22 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-02-22") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W09, Mar 01 2021", FullName = "[Time.Weekly].[2021].[W09, Mar 01 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-03-01") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W10, Mar 08 2021", FullName = "[Time.Weekly].[2021].[W10, Mar 08 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-03-08") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W11, Mar 15 2021", FullName = "[Time.Weekly].[2021].[W11, Mar 15 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-03-15") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W12, Mar 22 2021", FullName = "[Time.Weekly].[2021].[W12, Mar 22 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-03-22") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W13, Mar 29 2021", FullName = "[Time.Weekly].[2021].[W13, Mar 29 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-03-29") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W14, Apr 05 2021", FullName = "[Time.Weekly].[2021].[W14, Apr 05 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-04-05") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W15, Apr 12 2021", FullName = "[Time.Weekly].[2021].[W15, Apr 12 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-04-12") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W16, Apr 19 2021", FullName = "[Time.Weekly].[2021].[W16, Apr 19 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-04-19") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W17, Apr 26 2021", FullName = "[Time.Weekly].[2021].[W17, Apr 26 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-04-26") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W18, May 03 2021", FullName = "[Time.Weekly].[2021].[W18, May 03 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-05-03") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W19, May 10 2021", FullName = "[Time.Weekly].[2021].[W19, May 10 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-05-10") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W20, May 17 2021", FullName = "[Time.Weekly].[2021].[W20, May 17 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-05-17") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W21, May 24 2021", FullName = "[Time.Weekly].[2021].[W21, May 24 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-05-24") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W22, May 31 2021", FullName = "[Time.Weekly].[2021].[W22, May 31 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-05-31") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W23, Jun 07 2021", FullName = "[Time.Weekly].[2021].[W23, Jun 07 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-06-07") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W24, Jun 14 2021", FullName = "[Time.Weekly].[2021].[W24, Jun 14 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-06-14") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W25, Jun 21 2021", FullName = "[Time.Weekly].[2021].[W25, Jun 21 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-06-21") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W26, Jun 28 2021", FullName = "[Time.Weekly].[2021].[W26, Jun 28 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-06-28") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W27, Jul 05 2021", FullName = "[Time.Weekly].[2021].[W27, Jul 05 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-07-05") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W28, Jul 12 2021", FullName = "[Time.Weekly].[2021].[W28, Jul 12 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-07-12") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W29, Jul 19 2021", FullName = "[Time.Weekly].[2021].[W29, Jul 19 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-07-19") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W30, Jul 26 2021", FullName = "[Time.Weekly].[2021].[W30, Jul 26 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-07-26") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W31, Aug 02 2021", FullName = "[Time.Weekly].[2021].[W31, Aug 02 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-08-02") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W32, Aug 09 2021", FullName = "[Time.Weekly].[2021].[W32, Aug 09 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-08-09") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W33, Aug 16 2021", FullName = "[Time.Weekly].[2021].[W33, Aug 16 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-08-16") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W34, Aug 23 2021", FullName = "[Time.Weekly].[2021].[W34, Aug 23 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-08-23") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W35, Aug 30 2021", FullName = "[Time.Weekly].[2021].[W35, Aug 30 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-08-30") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W36, Sep 06 2021", FullName = "[Time.Weekly].[2021].[W36, Sep 06 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-09-06") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W37, Sep 13 2021", FullName = "[Time.Weekly].[2021].[W37, Sep 13 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-09-13") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W38, Sep 20 2021", FullName = "[Time.Weekly].[2021].[W38, Sep 20 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-09-20") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W39, Sep 27 2021", FullName = "[Time.Weekly].[2021].[W39, Sep 27 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-09-27") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W40, Oct 04 2021", FullName = "[Time.Weekly].[2021].[W40, Oct 04 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-10-04") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W41, Oct 11 2021", FullName = "[Time.Weekly].[2021].[W41, Oct 11 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-10-11") } },
                        new List<ReportResultRowPositionDto> { new ReportResultRowPositionDto { Name = "W42, Oct 18 2021", FullName = "[Time.Weekly].[2021].[W42, Oct 18 2021]", Drillable = true, Depth = 2, StartDate = DateTime.Parse("2021-10-18") } }
                    },
                    //FormattedValues= new[] { },
                    Values = new List<List<decimal?>>
                    {
                        new List<decimal?> { 151.0m, 6.0m, 8.0m },
                        new List<decimal?> { 151.0m, 6.0m, 9.0m },
                        new List<decimal?> { 150.0m, 8.0m, 9.0m },
                        new List<decimal?> { 152.0m, 9.0m, 11.0m },
                        new List<decimal?> { 160.0m, 5.0m, 9.0m },
                        new List<decimal?> { 160.0m, 8.0m, 7.0m },
                        new List<decimal?> { 162.0m, 8.0m, 6.0m },
                        new List<decimal?> { 162.0m, 9.0m, 6.0m },
                        new List<decimal?> { 164.0m, 10.0m, 9.0m },
                        new List<decimal?> { 167.0m, 13.0m, 16.0m },
                        new List<decimal?> { 168.0m, 15.0m, 15.0m },
                        new List<decimal?> { 180.0m, 5.0m, 18.0m },
                        new List<decimal?> { 181.0m, 7.0m, 15.0m },
                        new List<decimal?> { 183.0m, 5.0m, 15.0m },
                        new List<decimal?> { 184.0m, 5.0m, 15.0m },
                        new List<decimal?> { 184.0m, 7.0m, 14.0m },
                        new List<decimal?> { 188.0m, 5.0m, 15.0m },
                        new List<decimal?> { 188.0m, 5.0m, 18.0m },
                        new List<decimal?> { 188.0m, 10.0m, 17.0m },
                        new List<decimal?> { 192.0m, 9.0m, 14.0m },
                        new List<decimal?> { 195.0m, 7.0m, 14.0m },
                        new List<decimal?> { 196.0m, 6.0m, 15.0m },
                        new List<decimal?> { 196.0m, 6.0m, 16.0m },
                        new List<decimal?> { 197.0m, 6.0m, 15.0m },
                        new List<decimal?> { 198.0m, 6.0m, 15.0m },
                        new List<decimal?> { 199.0m, 6.0m, 15.0m },
                        new List<decimal?> { 201.0m, 4.0m, 24.0m },
                        new List<decimal?> { 204.0m, 5.0m, 20.0m },
                        new List<decimal?> { 204.0m, 9.0m, 16.0m },
                        new List<decimal?> { 204.0m, 11.0m, 15.0m },
                        new List<decimal?> { 211.0m, 4.0m, 15.0m },
                        new List<decimal?> { 213.0m, 3.0m, 16.0m },
                        new List<decimal?> { 223.0m, 6.0m, 15.0m },
                        new List<decimal?> { 223.0m, 6.0m, 18.0m },
                        new List<decimal?> { 226.0m, 10.0m, 20.0m },
                        new List<decimal?> { 228.0m, 10.0m, 22.0m },
                        new List<decimal?> { 233.0m, 10.0m, 23.0m },
                        new List<decimal?> { 235.0m, 9.0m, 23.0m },
                        new List<decimal?> { 240.0m, 7.0m, 23.0m },
                        new List<decimal?> { 245.0m, 8.0m, 23.0m },
                        new List<decimal?> { 248.0m, 5.0m, 26.0m },
                        new List<decimal?> { 250.0m, 5.0m, 24.0m }
                    },
                    FormattedValues = new List<List<string>>
                    {
                        new List<string> { "151", "6", "8" },
                        new List<string> { "151", "6", "9" },
                        new List<string> { "150", "8", "9" },
                        new List<string> { "152", "9", "11" },
                        new List<string> { "160", "5", "9" },
                        new List<string> { "160", "8", "7" },
                        new List<string> { "162", "8", "6" },
                        new List<string> { "162", "9", "6" },
                        new List<string> { "164", "10", "9" },
                        new List<string> { "167", "13", "16" },
                        new List<string> { "168", "15", "15" },
                        new List<string> { "180", "5", "18" } ,
                        new List<string> { "181", "7", "15" } ,
                        new List<string> { "183", "5", "15" } ,
                        new List<string> { "184", "5", "15" } ,
                        new List<string> { "184", "7", "14" } ,
                        new List<string> { "188", "5", "15" } ,
                        new List<string> { "188", "5", "18" } ,
                        new List<string> { "188", "10", "17" },
                        new List<string> { "192", "9", "14" },
                        new List<string> { "195", "7", "14" },
                        new List<string> { "196", "6", "15" },
                        new List<string> { "196", "6", "16" },
                        new List<string> { "197", "6", "15" },
                        new List<string> { "198", "6", "15" },
                        new List<string> { "199", "6", "15" },
                        new List<string> { "201", "4", "24" },
                        new List<string> { "204", "5", "20" },
                        new List<string> { "204", "9", "16" },
                        new List<string> { "204", "11", "15" },
                        new List<string> { "211", "4", "15" },
                        new List<string> { "213", "3", "16" },
                        new List<string> { "223", "6", "15" },
                        new List<string> { "223", "6", "18" },
                        new List<string> { "226", "10", "20" },
                        new List<string> { "233", "10", "23" },
                        new List<string> { "228", "10", "22" },
                        new List<string> { "235", "9", "23" },
                        new List<string> { "240", "7", "23" },
                        new List<string> { "245", "8", "23" },
                        new List<string> { "248", "5", "26" },
                        new List<string> { "250", "5", "24" }
                    }
                },
                Definition = new ReportResultDefinitionDto
                {

                    //":{"dimensions":[{"name":"Measures", "selected_set":["[Measures].[Issue history]"],
                    //"members":[]},{"name":"Transition Status","selected_set":["[Transition Status.Category].[Done]","[Transition Status.Category].[In Progress]","[Transition Status.Category].[To Do]"],"members":[],"bookmarked_members":[]
                    //}]},"rows":{ "dimensions":[{ "name":"Time","selected_set":["[Time.Weekly].[2021]"],"selected_set_expression":"DescendantsSet({{selected_set}}, [Time.Weekly].[Week])","members":[],"bookmarked_members":[]}],"nonempty_crossjoin":true},"pages":{ "dimensions":[{ "name":"Label","selected_set":["[Label].[All Labels]"],"members":[{ "depth":0,"name":"All Labels","full_name":"[Label].[All Labels]","drillable":true,"type":"all","expanded":true,"drilled_into":false}],"bookmarked_members":[],"current_page_members":["[Label].[All Labels]"]},{ "name":"Time","duplicate":true,"selected_set":["[Time.Weekly].[All Times]"],"members":[{ "depth":0,"name":"All Times","full_name":"[Time.Weekly].[All Times]","drillable":true,"type":"all","expanded":true,"drilled_into":false},{ "depth":1,"name":"2020","full_name":"[Time.Weekly].[2020]","drillable":true,"expanded":true,"drilled_into":false,"parent_full_name":"[Time.Weekly].[All Times]"},{ "depth":1,"name":"2021","full_name":"[Time.Weekly].[2021]","drillable":true,"expanded":false,"drilled_into":false,"parent_full_name":"[Time.Weekly].[All Times]"}],"bookmarked_members":[],"current_page_members":["[Time.Weekly].[2021]"]},{ "name":"Project","selected_set":["[Project.Category].[All Projects by category]"],"members":[{ "depth":0,"name":"All Projects by category","full_name":"[Project.Category].[All Projects by category]","drillable":true,"type":"all","expanded":true,"drilled_into":false},{ "depth":1,"name":"VET","full_name":"[Project.Category].[VET]","drillable":true,"expanded":true,"drilled_into":false,"parent_full_name":"[Project.Category].[All Projects by category]"},{ "depth":2,"name":"Cloud Platform","full_name":"[Project.Category].[VET].[Cloud Platform]","drillable":true,"key":"VET","parent_full_name":"[Project.Category].[VET]"},{ "depth":1,"name":"Tribo VET","full_name":"[Project.Category].[Tribo VET]","drillable":true,"expanded":true,"drilled_into":false,"parent_full_name":"[Project.Category].[All Projects by category]"},{ "depth":1,"name":"Tribo Plataforma","full_name":"[Project.Category].[Tribo Plataforma]","drillable":true,"expanded":true,"drilled_into":false,"parent_full_name":"[Project.Category].[All Projects by category]"}],"bookmarked_members":[],"current_page_members":["[Project.Category].[Fidelização].[Listas]"]},{ "name":"Issue Type","selected_set":["[Issue Type].DefaultMember"],"members":[{ "depth":0,"name":"All Issue Types","full_name":"[Issue Type].[All Issue Types]","drillable":true,"type":"all","expanded":true,"drilled_into":false},{ "depth":1,"name":"Task","full_name":"[Issue Type].[Task]","parent_full_name":"[Issue Type].[All Issue Types]"},{ "depth":1,"name":"Story","full_name":"[Issue Type].[Story]","parent_full_name":"[Issue Type].[All Issue Types]"}],"bookmarked_members":[],"current_page_members":["[Issue Type].[Task]","[Issue Type].[Story]"]}]},"options":{ "nonempty":"columns"},"view":{ "current":"timeline_chart","table":{ },"bar_chart":{ "stacked":false,"vertical":false,"swap_axes":false,"data_labels":false,"series_options":{ } },"line_chart":{ "area":false,"swap_axes":false,"data_labels":false},"pie_chart":{ "swap_axes":false,"donut":false,"show_legend":false,"show_labels":false,"data_labels":false,"relative_size":false,"series_options":{ } },"scatter_chart":{ "show_labels":false},"timeline_chart":{ "series_type":"column","stacked":true,"series_options":{ "To Do":{ "color":"#344563"},"In Progress":{ "color":"#2F579C"},"Done":{ "color":"#00875A"} } },"map_chart":{ "map_type":"static"},"gantt_chart":{ "timescale":"daily"},"gauge":{ "swap_axes":false,"only_values":false} },"calculated_members":[]}
                },
                CubeName = "Issues",
                LastImportAt = DateTime.Parse("2021-10-22T11:27:36.000Z")
            };
    }
}