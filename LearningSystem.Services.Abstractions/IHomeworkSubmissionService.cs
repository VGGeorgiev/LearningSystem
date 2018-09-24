namespace LearningSystem.Services.Abstractions
{
    public interface IHomeworkSubmissionService
    {
        void UploadHomework(int homeworkAssignmentId, int userId, byte[] file);

        int GetRandomHomeworkId(int homeworkAsssignmentId, int userId);

        byte[] DownloadHomework(int id);
    }
}
