import { Component, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MoradorApartamento, MoradorApartamentoFiltro } from '../../models/MoradorApartamento';
import { ResponseServiceAPI } from '../../models/ResponseServiceAPI';
import { MatTableDataSource } from '@angular/material/table';
import { MoradorService } from '../../services/morador.service';
import { Router } from '@angular/router';
import { ApartamentoService } from '../../services/apartamento.service';
import { MoradorApartamentoService } from '../../services/morador.apartamento';

@Component({
  selector: 'app-morador-apartamento',
  templateUrl: './morador-apartamento.component.html',
  styleUrls: ['./morador-apartamento.component.css']
})
export class MoradorApartamentoComponent {
  @ViewChild('paginator') paginator!: MatPaginator;

  moradoresApartamentos: MoradorApartamento[];

  nomeMorador: string = "";

  numeroApartamento: string = "";

  nomePredio: string = "";

  dataSource = new MatTableDataSource<any>;

  pageSize = 10;

  pageIndex = 0;

  pageEvent!: PageEvent;

  displayedColumns: string[] = ['id', 'morador.nome', 'apartamento.numeroApto', 'apartamento.predio.nomePredio', 'acaoExcluir'];


  respondeServiceAPI: ResponseServiceAPI;

  constructor(private moradorService: MoradorService, private apartamentoService: ApartamentoService,
              private moradorApartamentoService: MoradorApartamentoService, private router: Router) {
  }


  ngOnInit(): void {
    this.consultarMoradoresApartamentos();
  }

  consultarMoradoresApartamentos() {

    const filtroMoradorApartamento: MoradorApartamentoFiltro = {};

    if (this.nomeMorador != '' && this.nomeMorador != null) {
      filtroMoradorApartamento.nomeMorador = this.nomeMorador;
    }

    if (this.numeroApartamento != '' && this.numeroApartamento != null) {
      filtroMoradorApartamento.numeroApartamento = this.numeroApartamento;
    }

    if (this.nomePredio != '' && this.nomePredio != null) {
      filtroMoradorApartamento.nomePredio = this.nomePredio;
    }

    this.moradorApartamentoService.getMoradoresApartamentos(filtroMoradorApartamento).subscribe(res => {
      this.moradoresApartamentos = res;

      this.dataSource = new MatTableDataSource(this.moradoresApartamentos);
      this.dataSource.paginator = this.paginator;
    });
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
  }

  //onRowClick(row: any): void {
  //  this.router.navigate(['/morador/alteracao', row.id]);
  //  sessionStorage.setItem("SISCON_MANIPULADOR_CURRENT", "UPDATE");
  //  sessionStorage.setItem("ID_UPDATE", row.id);
  //}


  excluirItem(idMorador: string) {

    this.moradorService.deleteMorador(idMorador).subscribe(res => {
      this.respondeServiceAPI = res;

      this.consultarMoradoresApartamentos();

      alert(this.respondeServiceAPI.mensagem);

    });
  }

  botaoConsultar() {
    this.consultarMoradoresApartamentos();
  }

}
