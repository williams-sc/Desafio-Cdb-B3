import { CdbCalculateRequest } from './cdb-calculate-request';

describe('CdbCalculateRequest', () => {
  it('should create an instance', () => {
    expect(new CdbCalculateRequest(100,10)).toBeTruthy();
  });
});
