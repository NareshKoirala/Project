using OpenAI.Chat;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace API_Testing
{
    internal class Program
    {
        /// <summary>
        /// This is the main entry point for the application.
        /// 
        /// This test case are simply for api testing purposes. 
        ///                                                     --> Fetching jobs from JSearch and Remotive APIs, and testing OpenAI chat completion.
        ///                                                     --> It has valid jobs data and AI chat completion.
        ///                                                     --> Intial QuestPDF test case is also included to generate a simple PDF document.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TestCode testCode = new();

            //                      Uncomment the tests you want to run
            // testCode.OpenAIChatTest();
            // testCode.JSearchJobFetcherTest();
            // testCode.RemotiveJobFetcherTest();

            // This is an example of how to create a PDF document using QuestPDF
            //          - Valid Dictory path is required to save the PDF -> checks aswell creates if doesnt exists.
            //          - Valid Check for pre-existing PDF file.
            //testCode.DirectoryCreation(@"PDFs");
            //testCode.PDFExists(@".\PDFs\test.pdf");
            //testCode.QuestPDFTest("test");


            // This is an example of how to get the current directory and navigate to a specific path so net.9.0 inside of the bin fi`le to -> API Testing folder.
            //string currentDirectory = Directory.GetCurrentDirectory();
            //string apiTestingDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\.."));
            //Console.WriteLine(apiTestingDirectory);


            Console.ReadKey();
        }
    }

    public class TestCode
    {
        public void OpenAIChatTest()
        {
            string? apikey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            var client = new ChatClient(model: "gpt-3.5-turbo", apikey);

            ChatCompletion chatRequest = client.CompleteChat("Say 'This is a test.'");

            Console.WriteLine("Chat Response: " + chatRequest.Content[0].Text);
        }

        public void JSearchJobFetcherTest()
        {
            string url = "https://jsearch.p.rapidapi.com/search?query=developer%20jobs%20in%20edmonton&page=1&num_pages=1&country=ca&date_posted=all";

            var jobs = JobFetcher.JSearchJobFetcher(url).GetAwaiter().GetResult();
            if (jobs != null && jobs.data != null)
            {
                Console.WriteLine($"Total Jobs Found: {jobs.data.Count}");
                Console.WriteLine("Jobs:");
                foreach (var job in jobs.data)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine($"ID: {job.job_id}");
                    Console.WriteLine($"Title: {job.job_title}");
                    Console.WriteLine($"Company: {job.employer_name}");
                    Console.WriteLine($"Location: {job.job_location}");
                    Console.WriteLine($"Posted At: {job.job_posted_at_datetime_utc}");
                    Console.WriteLine($"Description: {job.job_description}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            else
            {
                Console.WriteLine("No jobs found or an error occurred.");
            }
        }

        public void RemotiveJobFetcherTest()
        {
            string url = "https://remotive.com/api/remote-jobs?limit=10";
            
            var jobs = JobFetcher.RemotiveJobFetcher(url).GetAwaiter().GetResult();
            if (jobs != null && jobs.jobs != null)
            {
                Console.WriteLine($"Total Jobs Found: {jobs.totaljobcount}");
                Console.WriteLine($"Job Count: {jobs.jobcount}");
                Console.WriteLine("Jobs:");
                foreach (var job in jobs.jobs)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine($"ID: {job.id}");
                    Console.WriteLine($"Title: {job.title}");
                    Console.WriteLine($"Company: {job.company_name}");
                    Console.WriteLine($"Location: {job.candidate_required_location}");
                    Console.WriteLine($"Publication Date: {job.publication_date}");
                    Console.WriteLine($"Salary: {job.salary}");
                    Console.WriteLine($"Description: {job.description}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            else
            {
                Console.WriteLine("No jobs found or an error occurred.");
            }
        }

        public void QuestPDFTest(string fileName)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // Example of using QuestPDF to create a simple PDF document
            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Arial"));

                    page.Content()
                        .Column(col =>
                        {
                            col.Item().Text("Naresh Prasad Koirala").FontSize(20).Bold();
                            col.Item().Text("Client Support Specialist (Aspiring) | Computer Engineering Technologist");
                            col.Item().Text("Edmonton, Alberta, Canada | chelseanaresh10@gmail.com | +1 780-916-5002");
                            col.Item().Text("Portfolio: nareshkoirala.github.io/MineRepo | GitHub | LinkedIn");

                            col.Item().PaddingVertical(10).Text("SUMMARY").FontSize(16).Bold();
                            col.Item().Text("Proactive and customer‑focused professional...");

                            col.Item().PaddingVertical(10).Text("PROFESSIONAL SKILLS").FontSize(16).Bold();
                            col.Item().Text(text =>
                            {
                                text.Span("• ").Bold();
                                text.Span("Customer Support & Account Management");
                            });
                            col.Item().Text(text =>
                            {
                                text.Span("• ").Bold();
                                text.Span("Issue Resolution and Root‑Cause Analysis");
                            });

                            col.Item().PaddingVertical(10).Text("EDUCATION").FontSize(16).Bold();
                            col.Item().Text("Northern Alberta Institute of Technology (NAIT) – Edmonton, Canada");
                            col.Item().Text("Computer Engineering Technology — Jan 2023 – Apr 2025");
                        });
                });
            }).GeneratePdf($@"C:\PDFs\{fileName}.pdf");

            Console.WriteLine("PDF generated successfully.");
        }

        public string DirectoryCreation(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    return "Directory created successfully.";
                }
                else
                {
                    return "Directory already exists.";
                }
            }
            catch (Exception ex)
            {
                return $"Error creating directory: {ex.Message}";
            }
        }

        public bool PDFExists(string path)
        {
            try
            {
                return File.Exists(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking PDF existence: {ex.Message}");
                return false;
            }
        }
    }
}
