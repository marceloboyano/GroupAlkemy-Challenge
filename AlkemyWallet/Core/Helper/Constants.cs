namespace AlkemyWallet.Core.Helper
{
    public static class Constants
    {
        // transaction message
        public const string TRAN_NOT_EXISTS = "No existe una transacción con el id proporcionado asociada al usuario";
        public const string TRAN_DELETED = "La transacción ha sido eliminada";
        public const string TRAN_NOT_FOUND = "No se encontró la transacción";
        public const string TRAN_UPDATED = "Transacción modificada con éxito";
        public const string TRAN_CREATED = "Transacción creada con éxito";
        public const string TRAN_NOT_CREATED = "Transacción incorrecta. No se procedió con la creación";

        // Account message
        public const string ACC_NOT_FOUND_MESSAGE = "El id de la cuenta que ingreso no fue encontrado.";
        public const string ACC_BLOCK_MESSAGE = "Su cuenta esta bloqueada, no puede realizar operaciones.";
        public const string ACC_AMOUNT_LESS_THAN_ZERO_MESSAGE = "El importe ingresado debe ser mayor a 0";
        public const string ACC_PENDING_TRANSACTIONS_MESSAGE = "No se puede eliminar la cuenta mientras tenga inversiones o depositos pendientes";
        public const string DB_NOT_EXPECTED_RESULT_MESSAGE = "Algo ha salido mal cuando se intento guardar los cambios!!!";
        public const string ACC_DELETED_MESSAGE = "Cuenta eliminada.";
        public const string ACC_INSUFFICIENT_FUNDS_MESSAGE = "El dinero disponible en la cuenta es menor que el importe a transferir.";
        public const string ACC_SAME_ACCOUNT_MESSAGE = "La cuenta de destino es igual a la de origen. No se puede transferir a la misma cuenta.";
        public const string ACC_TRANSFER_SUCCESSFUL_MESSAGE = "Transferencia exitosa.";
        public const string ACC_BLOCK_SUCCESSFUL_MESSAGE = "La cuenta ha sido Bloqueada.";
        public const string ACC_UNBLOCK_SUCCESSFUL_MESSAGE = "La cuenta ha sido Desbloqueada.";
        public const string ACC_SUCCESSFUL_ACCOUNT_MESSAGE = "Se ha creado la cuenta exitosamente";
        public const string ACC_SUCCESSFUL_ACCOUNT_MODIFIED_MESSAGE = "Cuenta Modificada con exito";
        public const string ACC_NOT_MATCHED_MESSAGE = "El id de cuenta ingresado no coincide con el id de usuario registrado en el sistema";

    }
}


