export class CdbCalculateRequest {
  initialAmount: number;
  monthlyTerm: number;

  constructor(initialAmount: number, monthlyTerm: number) {
    this.initialAmount = initialAmount;
    this.monthlyTerm = monthlyTerm;
  }
}
