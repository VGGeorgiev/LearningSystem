namespace LearningSystem.Services
{
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Services.Abstractions;
    using System;
    using System.Linq;

    public class HomeworkSubmissionService : IHomeworkSubmissionService
    {
        private IRepository<HomeworkSubmission> homeworkSubmissionRepository;
        private Random random = new Random();

        public HomeworkSubmissionService(IRepository<HomeworkSubmission> homeworkSubmissionRepository)
        {
            this.homeworkSubmissionRepository = homeworkSubmissionRepository;
        }

        public byte[] DownloadHomework(int id)
        {
            var homework = this.homeworkSubmissionRepository.Get(id);
            return homework.File;
        }

        public int GetRandomHomeworkId(int homeworkAssignmentId, int userId)
        {
            var homeworkSubmissionsIds = this.homeworkSubmissionRepository
                .Include(x => x.HomeworkEvaluations)
                .GetAll()
                .Where(x => x.HomeworkAssignmentId == homeworkAssignmentId && x.UserId != userId)
                .Where(x => !x.HomeworkEvaluations.Any(e => e.EvaluatedById == userId))
                .Select(x => x.Id)
                .ToList();

            if (homeworkSubmissionsIds.Any())
            {
                var randomHomeworkId = homeworkSubmissionsIds.ElementAt(random.Next(homeworkSubmissionsIds.Count()));
                return randomHomeworkId;
            }

            return 0;
        }

        public void UploadHomework(int homeworkAssignmentId, int userId, byte[] file)
        {
            var homework = new HomeworkSubmission()
            {
                UserId = userId,
                HomeworkAssignmentId = homeworkAssignmentId,
                File = file,
                CreatedDate = DateTime.Now,
            };

            this.homeworkSubmissionRepository.Insert(homework);
        }
    }
}
