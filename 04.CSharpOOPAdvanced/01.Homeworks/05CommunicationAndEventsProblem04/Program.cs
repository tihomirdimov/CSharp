using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05CommunicationAndEventsProblem04
{
    public class JobDoneArgs : EventArgs
    {
        public JobDoneArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
    public abstract class Employee
    {
        protected Employee(string name, int workingHours)
        {
            this.Name = name;
            this.WorkingHours = workingHours;
        }

        public string Name { get; }

        public int WorkingHours { get; }
    }
    public class PartTimeEmployee : Employee
    {
        private const int EmployeeWorkingHours = 20;

        public PartTimeEmployee(string name)
            : base(name, EmployeeWorkingHours)
        {
        }
    }
    public class StandartEmployee : Employee
    {
        private const int EmployeeWorkingHours = 40;

        public StandartEmployee(string name)
            : base(name, EmployeeWorkingHours)
        {
        }
    }
    public class EmployeeRopository
    {
        private readonly Dictionary<string, Employee> employees;

        public EmployeeRopository()
        {
            this.employees = new Dictionary<string, Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            this.employees.Add(employee.Name, employee);
        }

        public Employee GetEmployee(string name)
        {
            return this.employees[name];
        }
    }
    public class JobRepository
    {
        private readonly List<Job> jobs;

        public JobRepository()
        {
            this.jobs = new List<Job>();
        }

        public void AddJob(Job job)
        {
            this.jobs.Add(job);
        }

        public void FinishedJob(object sender, JobDoneArgs args)
        {
            Console.WriteLine($"Job {args.Name} done!");
            var job = this.jobs
                .FirstOrDefault(j => j.Name.Equals(args.Name));

            this.jobs.Remove(job);
        }

        public void Update()
        {
            var jobsToUpdate = new List<Job>(this.jobs);

            foreach (var job in jobsToUpdate)
            {
                job.Update();
            }
        }

        public void Status()
        {
            foreach (var job in this.jobs)
            {
                Console.WriteLine($"Job: {job.Name} Hours Remaining: {job.HoursOfWorkRequired}");
            }
        }
    }

    public delegate void JobDoneEventHandler(object sender, JobDoneArgs args);

    public class Job
    {
        private readonly Employee employee;

        public Job(string name, int hoursOfWorkRequired, Employee employee)
        {
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.employee = employee;
        }

        public event JobDoneEventHandler JobDone;

        public string Name { get; }

        public int HoursOfWorkRequired { get; private set; }

        public void Update()
        {
            this.HoursOfWorkRequired -= this.employee.WorkingHours;

            if (this.HoursOfWorkRequired <= 0)
            {
                this.OnJobDone(new JobDoneArgs(this.Name));
            }
        }

        public void OnJobDone(JobDoneArgs args)
        {
            this.JobDone?.Invoke(this, args);
        }
    }
    class Program
    {
        public static void Main()
        {
            var jobs = new JobRepository();
            var employees = new EmployeeRopository();

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!input[0].Equals("End"))
            {
                switch (input[0])
                {
                    case "Job":
                        {
                            var jobName = input[1];
                            var jobHoursRequired = int.Parse(input[2]);
                            var employee = employees.GetEmployee(input[3]);

                            var job = new Job(jobName, jobHoursRequired, employee);
                            job.JobDone += jobs.FinishedJob;
                            jobs.AddJob(job);
                        }

                        break;
                    case "StandartEmployee":
                        {
                            var employeeName = input[1];
                            var employee = new StandartEmployee(employeeName);
                            employees.AddEmployee(employee);
                        }

                        break;
                    case "PartTimeEmployee":
                        {
                            var employeeName = input[1];
                            var employee = new PartTimeEmployee(employeeName);
                            employees.AddEmployee(employee);
                        }

                        break;
                    case "Pass":
                        jobs.Update();
                        break;
                    case "Status":
                        jobs.Status();
                        break;
                }

                input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
