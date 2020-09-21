import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ModalControleService {

private _displayModalNovoMembro = false;

  get situacaoModalNovoMembro() {
    return this._displayModalNovoMembro;
  }

  fecharModalNovoMembro() {
    this._displayModalNovoMembro = false;
  }

  abrirModalNovoMembro() {
    this._displayModalNovoMembro = true;
  }

  constructor() { }
}
