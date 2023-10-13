import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'cpfCnpjFormat'
})
export class CpfCnpjFormatPipe implements PipeTransform {

  transform(value: string): unknown {
    if (!value) {
      return '';
    }

    value = value.replace(/\D/g, '');

    if (value.length === 11) {
      return value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');
    }
    else if (value.length === 14) { // CNPJ
      return value.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5');
    }
    else {
      return value;
    }
  }

}
