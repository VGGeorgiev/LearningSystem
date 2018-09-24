export class SeasonInput {
  id: number;
  name: string;
  startDate: Date;
  studentsLimit: number;
}

export class Season extends SeasonInput {
  isUserApplied: boolean;
}
