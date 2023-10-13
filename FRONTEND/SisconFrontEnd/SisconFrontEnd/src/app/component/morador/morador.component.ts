import { Component, OnInit, ViewChild } from '@angular/core';
import { Morador } from '../../models/Morador';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ResponseServiceAPI } from '../../models/ResponseServiceAPI';
import { MoradorService } from '../../services/morador.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-morador',
  templateUrl: './morador.component.html',
  styleUrls: ['./morador.component.css']
})
export class MoradorComponent implements OnInit {

  @ViewChild('paginator') paginator!: MatPaginator;

  moradores: Morador[];

  nomeMorador: string = "";

  dataSource = new MatTableDataSource<any>;

  pageSize = 10;

  pageIndex = 0;

  pageEvent!: PageEvent;

  displayedColumns: string[] = ['id', 'nome', 'dataNascimento', 'email', 'telefone', 'acaoExcluir'];

  respondeServiceAPI: ResponseServiceAPI;

  constructor(private moradorService: MoradorService, private router: Router) {
  }

  ngOnInit(): void {
    this.consultarMoradores();
  }

  consultarMoradores() {
    this.moradorService.getMoradores(this.nomeMorador).subscribe(res => {
      this.moradores = res;

      this.dataSource = new MatTableDataSource(this.moradores);
      this.dataSource.paginator = this.paginator;
    });
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
  }

  onRowClick(row: any): void {
    this.router.navigate(['/morador/alteracao', row.id]);
    sessionStorage.setItem("SISCON_MANIPULADOR_CURRENT", "UPDATE");
    sessionStorage.setItem("ID_UPDATE", row.id);
  }

  IncluirMorador() {
    this.router.navigate(['/morador/inclusao']);
    sessionStorage.setItem("SISCON_MANIPULADOR_CURRENT", "INSERT");
  }

  excluirItem(idMorador: string) {

    this.moradorService.deleteMorador(idMorador).subscribe(res => {
      this.respondeServiceAPI = res;

      this.consultarMoradores();

      alert(this.respondeServiceAPI.mensagem);

    });
  }

  botaoConsultar() {
    this.consultarMoradores();
  }

}
