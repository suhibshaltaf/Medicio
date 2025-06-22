using AutoMapper;
using Medicio.DAL.Models;
using Medicio.PL.Areas.Dashboard.ViewModels.AppointmentVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.DepartmentsVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.DoctorsVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.FeaturesVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.PricingVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.QuestionsVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.ServiceVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.SliderVIMO;
using Medicio.PL.Areas.Dashboard.ViewModels.TestimonialsVIMO;

namespace Medicio.PL.Mapping
{
    public class MappingProfile :Profile
    {
            public MappingProfile() {
            CreateMap<ServiceFormVM, Service>().ReverseMap();
            CreateMap<Service, ServicesVM>();
            CreateMap<Service, serviceDetailsVM>();
            CreateMap<DepartmentsFormVM, Departments>().ReverseMap();
            CreateMap<Departments, DepartmentsVM>().ReverseMap();
            CreateMap<Departments, DepartmentsDetailsVM>().ReverseMap();
            CreateMap<DoctorFormVM, Doctors>().ReverseMap();
            CreateMap<Doctors, DoctorsVM>().ForMember(dest=>dest.DepartmentName,opt=>opt.MapFrom(src=>src.department.Title));
            CreateMap<Doctors, DoctorDetailsVM>().ReverseMap();
            CreateMap<TestimonialsFormVM, Testimonials>().ReverseMap();
            CreateMap<Testimonials, TestimonialsVM>().ReverseMap();
            CreateMap<Testimonials, TestimonialsDetailsVM>().ReverseMap();
            CreateMap<Questions,QuestionsVM>().ReverseMap();
            CreateMap<PricingFormVM, Pricing>().ReverseMap();
            CreateMap<Pricing, PricingVM>();
            CreateMap<Pricing, PricingDetailsVM>();
            CreateMap<AppointmentFormVM, Appointment>().ReverseMap();
            CreateMap<Appointment, AppointmentVM>();
            CreateMap<Appointment, AppointmentDetailsVM>();
            CreateMap<SliderFormVM, Slider>().ReverseMap();

            CreateMap<Slider, SliderVM>().ReverseMap();
            CreateMap<Slider, SliderDetailsVM>().ReverseMap();
            CreateMap<FeaturesFormVM, Features>().ReverseMap();
            CreateMap<Features, FeaturesVM>();
            CreateMap<Features, FeaturesDetailsVM>();
            

        }

    }
}
