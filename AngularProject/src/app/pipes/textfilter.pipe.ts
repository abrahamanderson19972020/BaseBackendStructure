import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../models/product.model';

@Pipe({
  name: 'textfilter',
})
export class TextfilterPipe implements PipeTransform {
  transform(value: Product[], filterText: string): Product[] {
    return filterText
      ? value.filter(
          (product) =>
            product.productName
              .toLocaleLowerCase()
              .indexOf(filterText.toLocaleLowerCase()) !== -1
        )
      : value;
  }
}
