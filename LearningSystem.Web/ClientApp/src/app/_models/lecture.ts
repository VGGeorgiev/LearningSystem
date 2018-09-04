import { HomeworkAssignment } from "./homeworkAssignment";
import { SafeResourceUrl } from "@angular/platform-browser";

export class Lecture {
  id: number;
  name: string;
  description: string;
  videoUrl: string;
  safeVideoUrl: SafeResourceUrl;
  homeworkAssignments: HomeworkAssignment[];
}
