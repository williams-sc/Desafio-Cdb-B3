export class CdbCalculateResponse {
  totalAmountGross: number;
  totalAmountNet: number;

  constructor(
    totalAmountGross: number,
    totalAmountNet: number,
  ) {
    this.totalAmountGross = totalAmountGross;
    this.totalAmountNet = totalAmountNet;
  }
}
