export interface RetornoServidor<T> {
  
  operacionExitosa: boolean;
  resultadoEspecifico: T;
  listadoResultados: T[];
  error: string;
}



