import { Product } from './product.model';

export interface ProductResponse<T> {
  data: T[];
  success: boolean;
  message: string;
}
