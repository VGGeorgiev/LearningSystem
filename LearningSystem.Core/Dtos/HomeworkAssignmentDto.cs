﻿using System;

namespace LearningSystem.Core.Dtos
{
    public class HomeworkAssignmentDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Deadline { get; set; }

        public string LectureName { get; set; }

        public string LectureId { get; set; }

        public bool HasUserSubmission { get; set; }
    }
}