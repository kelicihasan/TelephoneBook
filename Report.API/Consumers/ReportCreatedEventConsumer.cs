using MassTransit;
using Report.Application.Services.Abstract;
using Report.Domain.Entities;
using Report.Domain.Enums;
using Shared.Events;

namespace Report.API.Consumers
{
    public class ReportCreatedEventConsumer : IConsumer<ReportCreateEvent>
    {
        readonly IPersonContactService _personContactService;
        readonly IReportDetailService _reportDetailService;
        readonly IReportService _reportService;
        public ReportCreatedEventConsumer(
            IPersonContactService personContactService,
            IReportDetailService reportDetailService,
            IReportService reportService)
        {
            _personContactService = personContactService;
            _reportDetailService = reportDetailService;
            _reportService = reportService;
        }
        public async Task Consume(ConsumeContext<ReportCreateEvent> context)
        {
            var reportDetail = new List<ReportDetail>();
            _personContactService.GetAll().Result.ForEach(s =>
            {
                reportDetail.Add(new ReportDetail
                {
                    ReportId = context.Message.ReportId,
                    Location = s.Location,
                    PhoneNumberCount = s.PhoneNumberCount,
                    PersonCount = s.PersonCount
                });

            });
            await _reportDetailService.BulkCreate(reportDetail);
            var report = await _reportService.GetById(context.Message.ReportId);
            report.ReportState = nameof(ReportStatus.Tamamlandi);
            await _reportService.Update(report, x => x.Id == report.Id);
        }
    }
}
