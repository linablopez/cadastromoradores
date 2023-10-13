import { Component, ViewChild, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Apartamento } from '../../models/Apartamento';
import { ApartamentoService } from '../../services/apartamento.service';
import { Router } from '@angular/router';
import { ResponseServiceAPI } from '../../models/ResponseServiceAPI';

@Component({
  selector: 'app-apartamento',
  templateUrl: './apartamento.component.html',
  styleUrls: ['./apartamento.component.css']
})
export class ApartamentoComponent implements OnInit {

  @ViewChild('paginator') paginator!: MatPaginator;

  apartamentos: Apartamento[] = [];

  numeroApartamento: string = "";
  andarApartamento: string = "";

  dataSource = new MatTableDataSource<any>;

  pageSize = 10;

  pageIndex = 0;

  pageEvent!: PageEvent;

  displayedColumns: string[] = ['id', 'predio.nomePredio', 'numeroApto', 'andar', 'acaoExcluir'];

  respondeServiceAPI: ResponseServiceAPI;

  constructor(private apartamentoService: ApartamentoService, private router: Router) {
  }

  ngOnInit(): void {
    this.consultarApartamentos();
  }

  consultarApartamentos() {
    this.apartamentoService.getApartamentos(this.numeroApartamento, this.andarApartamento).subscribe(res => {
      this.apartamentos = res;

      this.dataSource = new MatTableDataSource(this.apartamentos);
      this.dataSource.paginator = this.paginator;
    });
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
  }

  onRowClick(row: any): void {
    this.router.navigate(['/apartamento/alteracao', row.id]);
    sessionStorage.setItem("SISCON_MANIPULADOR_CURRENT", "UPDATE");
    sessionStorage.setItem("ID_UPDATE", row.id);
  }

  IncluirApartamento() {
    this.router.navigate(['/apartamento/inclusao']);
    sessionStorage.setItem("SISCON_MANIPULADOR_CURRENT", "INSERT");
  }

  excluirItem(idApartamento: string) {

    this.apartamentoService.deleteApartamento(idApartamento).subscribe(res => {
      this.respondeServiceAPI = res;

      this.consultarApartamentos();

      alert(this.respondeServiceAPI.mensagem);

    });
  }

  botaoConsultar() {
    this.consultarApartamentos();
  }

}
