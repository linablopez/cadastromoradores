import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { Morador } from '../../models/Morador';
import { Sexo } from '../../models/Sexo';
import { TipoDocumento } from '../../models/TipoDocumento';
import { MoradorService } from '../../services/morador.service';
import { SexoService } from '../../services/sexo.service';
import { TipoDocumentoService } from '../../services/tipoDocumento.service';
import { Router } from '@angular/router';
import { ResponseServiceAPI } from '../../models/ResponseServiceAPI';
import Inputmask from 'inputmask';

@Component({
  selector: 'app-morador-detalhe',
  templateUrl: './morador-detalhe.component.html',
  styleUrls: ['./morador-detalhe.component.css']
})
export class MoradorDetalheComponent {
  @ViewChild('botao-incluir') botaoIncluir: ElementRef;
  @ViewChild('botao-alterar') botaoAlterar: ElementRef;

  morador: Morador;
  moradorId: string;
  sexos: Sexo[];
  sexoId: string;
  sexoSelected: Sexo | undefined;
  tiposDocumentos: TipoDocumento[];
  tipoDocumentoId: string;
  tipoDocumentoSelected: TipoDocumento | undefined;
  nome: string;
  numeroDocumento: string;
  dataNascimento: Date;
  idade: number;
  telefone: string;
  email: string;
  responseServiceAPI: ResponseServiceAPI;

  constructor(private moradorService: MoradorService, private sexoService: SexoService,
              private tipoDocumentoService: TipoDocumentoService, private router: Router) {
  }

  ngAfterViewInit() {
    const telefoneInput = document.getElementById('telefone');

    if (telefoneInput) {
      Inputmask({ mask: '(99) 99999-9999[10]', showMaskOnHover: false }).mask(telefoneInput);
    }

    const idadeInput = document.getElementById('idade');

    if (idadeInput) {
      Inputmask('numeric', { radixPoint: '', rightAlign: false }).mask(idadeInput);
    }

  }

  ngOnInit(): void {
    let botaoIncluir = <HTMLButtonElement>document.getElementById("botao-incluir");
    let botaoAlterar = <HTMLButtonElement>document.getElementById("botao-alterar");

    this.consultarSexos();
    this.consultarTiposDocumentos();

    if (sessionStorage.getItem("SISCON_MANIPULADOR_CURRENT") != "") {
      if (sessionStorage.getItem("SISCON_MANIPULADOR_CURRENT") == "UPDATE") {
        this.moradorId = sessionStorage.getItem("ID_UPDATE") ?? "";
        botaoIncluir.style.display = "none";
        botaoAlterar.style.display = "block";
        sessionStorage.removeItem("SISCON_MANIPULADOR_CURRENT");
        sessionStorage.removeItem("ID_UPDATE");

        this.moradorService.getMorador(this.moradorId).subscribe(res => {
          this.morador = res;
          if (this.morador) {
            this.nome = this.morador.nome?.toString() ?? "";
            this.tipoDocumentoId = this.morador.tipoDocumentoId?.toString() ?? "";

            this.sexoId = this.morador.sexoId?.toString() ?? "";
            this.numeroDocumento = this.morador.numeroDocumento?.toString() ?? "";
            if (this.morador.dataNascimento) {
              this.dataNascimento = new Date(this.morador.dataNascimento);
            }
            this.idade = this.morador.idade ?? 0;
            this.telefone = this.morador.telefone?.toString() ?? "";
            this.email = this.morador.email?.toString() ?? "";

          } else {
            this.nome = "";
            this.numeroDocumento = "";
            this.telefone = "";
            this.email = "";
          }

        });
      }
      else {
        botaoIncluir.style.display = "block";
        botaoAlterar.style.display = "none";

        if (sessionStorage.getItem("ID_UPDATE") != "") {
          sessionStorage.removeItem("SISCON_MANIPULADOR_CURRENT");
        }
      }
    }
  }

  public consultarSexos() {
    this.sexoService.getAllSexos().subscribe(res => {
      this.sexos = res;
      this.sexoId = res[0].id.toString();
    });
  }

  sexoSelecionadoChanged() {
    this.sexoSelected = this.sexos
      .find(sexo => sexo.id === this.morador.sexoId);
  }

  public consultarTiposDocumentos() {
    this.tipoDocumentoService.getAllTipoDocumentos().subscribe(res => {
      this.tiposDocumentos = res;
      this.tipoDocumentoId = res[0].id.toString();
    });
  }

  TiposDocumentosSelecionadoChanged() {
    this.tipoDocumentoSelected = this.tiposDocumentos
      .find(tiposDocumento => tiposDocumento.id === this.morador.tipoDocumentoId);
  }

  incluirDadosMorador() {

    if (this.nome == "") {
      alert("É necessário preencher o Nome do Morador");
      return;
    }

    if (this.numeroDocumento == "") {
      alert("É necessário preencher o Número do Documento do Morador");
      return;
    }

    if (!this.dataNascimento) {
      alert("É necessário preencher a Data de Nascimento do Morador");
      return;
    }

    if (!this.idade) {
      alert("É necessário preencher a Idade do Morador");
      return;
    }

    if (this.telefone == "") {
      alert("É necessário preencher o Telefone do Morador");
      return;
    }

    if (this.email == "") {
      alert("É necessário preencher o E-mail do Morador");
      return;
    }

    const jsonMorador = {
      numeroDocumento: this.numeroDocumento,
      tipoDocumentoId: this.tipoDocumentoId,
      nome: this.nome,
      dataNascimento: this.dataNascimento,
      idade: this.idade,
      sexoId: this.sexoId,
      telefone: this.telefone,
      email: this.email
    };

    this.moradorService.incluirMorador(JSON.stringify(jsonMorador)).subscribe(res => {
      this.responseServiceAPI = res;

      alert(res.mensagem);

      this.router.navigate(['/moradores']);
    });

  }

  alterarDadosMorador() {
    if (this.nome == "") {
      alert("É necessário preencher o Nome do Morador");
      return;
    }

    if (this.numeroDocumento == "") {
      alert("É necessário preencher o Número do Documento do Morador");
      return;
    }

    if (!this.dataNascimento) {
      alert("É necessário preencher a Data de Nascimento do Morador");
      return;
    }

    if (!this.idade) {
      alert("É necessário preencher a Idade do Morador");
      return;
    }

    if (this.telefone == "") {
      alert("É necessário preencher o Telefone do Morador");
      return;
    }

    if (this.email == "") {
      alert("É necessário preencher o E-mail do Morador");
      return;
    }

    const jsonMorador = {
      numeroDocumento: this.numeroDocumento,
      tipoDocumentoId: this.tipoDocumentoId,
      nome: this.nome,
      dataNascimento: this.dataNascimento,
      idade: this.idade,
      sexoId: this.sexoId,
      telefone: this.telefone,
      email: this.email
    };

    this.moradorService.alterarMorador(this.moradorId,JSON.stringify(jsonMorador)).subscribe(res => {
      this.responseServiceAPI = res;

      alert(res.mensagem);

      this.router.navigate(['/moradores']);
    });
  }


}
