import { RegisterDetail } from './registerDetail.model';
export interface RegisterResponse {
  data: RegisterDetail;
  success: boolean;
  message: string;
}
