import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'numberFormatPipe'
})
export class NumberFormatPipePipe implements PipeTransform {

  transform(value: number, locale: string = 'pt-BR', formatOptions?: any): string {
    return value.toLocaleString(locale, {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    });
  }

}
