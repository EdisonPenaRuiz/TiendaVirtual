export class RetornoServidor {
  constructor(operacionExitosa: boolean, resultadoEspecifico: Object, listadoResultados: Object[], error: string) {
    this.OperacionExitosa = operacionExitosa;
    this.ListadoResultados = listadoResultados;
    this.ResultadoEspecifico = resultadoEspecifico;
    this.Error = error;
  }
  OperacionExitosa: boolean;
  ResultadoEspecifico: Object;
  ListadoResultados: Object[];
  Error: string;
}

export class Respuesta {
  constructor(respuesta: RetornoServidor) {
    this.RespuesServidor = respuesta;
  }
  RespuesServidor: RetornoServidor;
}
