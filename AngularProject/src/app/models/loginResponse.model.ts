import { LoginDetail } from './loginDetail.model';
export interface LoginResponse {
  data: LoginDetail;
  success: boolean;
  message: string;
}
