import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'vat',
})
export class VatPipe implements PipeTransform {
  transform(value: number, rate: number): number {
    return value + (value * rate) / 100;
  }
}
