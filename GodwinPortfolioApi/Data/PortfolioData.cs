using GodwinPortfolioApi.Models;

namespace GodwinPortfolioApi.Data;

public static class PortfolioData
{
    public static PortfolioProfile BuildProfile()
    {
        return new PortfolioProfile
        {
            Name = "Godwin Chukwuebuka Igwegbe",
            Title = "Backend Developer & DevOps Engineer",
            Summary =
                "Results-driven Backend & DevOps Engineer specializing in ASP.NET Core, C#, scalable microservices, containerization, CI/CD automation and application observability.",
            Location = "Ajah, Lagos, Nigeria",
            Email = "godwincliff10@gmail.com",
            Phone = "09075948313",
            GitHub = "https://github.com/HendrixCliff",
            PortfolioUrl = "https://godwin-portfolio-ivory.vercel.app/",
            Education =
                "Bachelor of Engineering: Civil Engineering — Chukwuemeka Odumegwu Ojukwu University, Uli, Anambra State."
        };
    }

    public static List<Experience> BuildExperience()
    {
        return
        [
            new Experience
            {
                Company = "Independent Backend Developer",
                Role = "Backend Developer & DevOps Engineer",
                Period = "July 2024 - Present",
                Description =
                    "Building scalable backend systems and cloud-native applications with a strong focus on clean architecture, automation, observability and reliable deployment.",
                Highlights =
                [
                    "Implemented Clean Architecture and CQRS/MediatR patterns.",
                    "Implemented JWT authentication and role-based access control.",
                    "Built RESTful APIs using ASP.NET Core and C#.",
                    "Worked with PostgreSQL and Entity Framework Core.",
                    "Integrated Paystack for payment processing.",
                    "Integrated Cloudinary for media management.",
                    "Implemented SMTP-based email functionality.",
                    "Integrated Gemini AI capabilities into applications.",
                    "Containerized applications using Docker and Docker Compose.",
                    "Implemented CI/CD automation with GitHub Actions.",
                    "Implemented application monitoring with Prometheus, Grafana and Seq.",
                    "Deployed applications to AWS EC2.",
                    "Managed Linux services using systemd.",
                    "Implemented Redis for caching and performance optimization."
                ],
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Entity Framework Core",
                    "PostgreSQL",
                    "Redis",
                    "Docker",
                    "GitHub Actions",
                    "AWS EC2",
                    "Prometheus",
                    "Grafana",
                    "Seq"
                ]
            }
        ];
    }

    public static List<Project> BuildProjects()
    {
        return
        [
            new Project
            {
                Name = "WorkServices",
                Description =
                    "A backend-focused application demonstrating scalable API development, authentication, database integration, payment processing and cloud-native engineering practices.",
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Entity Framework Core",
                    "PostgreSQL",
                    "Redis",
                    "JWT",
                    "CQRS",
                    "MediatR",
                    "Docker",
                    "GitHub Actions"
                ]
            },

            new Project
            {
                Name = "PayVault",
                Description =
                    "A payment-oriented backend application integrating secure payment processing and backend business workflows.",
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "PostgreSQL",
                    "Entity Framework Core",
                    "Paystack",
                    "JWT"
                ]
            },

            new Project
            {
                Name = "GrowthPilot",
                Description =
                    "An application focused on business growth workflows and AI-assisted functionality.",
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Entity Framework Core",
                    "PostgreSQL",
                    "Gemini AI",
                    "Docker"
                ]
            },

            new Project
            {
                Name = "MooreHotelAndSuites",
                Description =
                    "A hotel management and booking-oriented application providing backend functionality for hotel operations.",
                Technologies =
                [
                    "ASP.NET Core",
                    "C#",
                    "Entity Framework Core",
                    "PostgreSQL",
                    "REST API",
                    "Docker"
                ]
            }
        ];
    }

    public static List<SkillGroup> BuildSkills()
    {
        return
        [
            new SkillGroup
            {
                Category = "Backend Engineering",
                Skills =
                [
                    "C#",
                    "ASP.NET Core",
                    "REST APIs",
                    "Clean Architecture",
                    "CQRS",
                    "MediatR",
                    "JWT Authentication",
                    "Role-Based Access Control",
                    "Microservices"
                ]
            },

            new SkillGroup
            {
                Category = "Databases",
                Skills =
                [
                    "PostgreSQL",
                    "SQL Server",
                    "Entity Framework Core",
                    "Redis"
                ]
            },

            new SkillGroup
            {
                Category = "DevOps & Cloud",
                Skills =
                [
                    "Docker",
                    "Docker Compose",
                    "GitHub Actions",
                    "AWS EC2",
                    "CI/CD",
                    "Linux",
                    "systemd"
                ]
            },

            new SkillGroup
            {
                Category = "Monitoring",
                Skills =
                [
                    "Prometheus",
                    "Grafana",
                    "Seq",
                    "Application Observability"
                ]
            },

            new SkillGroup
            {
                Category = "Tools",
                Skills =
                [
                    "Git",
                    "GitHub",
                    "Visual Studio",
                    "VS Code",
                    "Postman",
                    "Swagger"
                ]
            }
        ];
    }
}