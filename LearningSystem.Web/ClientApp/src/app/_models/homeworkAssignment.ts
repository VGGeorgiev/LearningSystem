export class HomeworkAssignment {
  id: number;
  content: string;
  deadline: Date;
  hasUserSubmission: boolean;
}

export class HomeworkAssignmentInput {
  id: number;
  content: string;
  deadline: Date;
  lectureId: number;
  lectureName: string;
}
