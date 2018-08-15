using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntity
{
    public class TPSLResponse
    {
        public String MERCHANTID { get; set; }
        public String CustomerID { get; set; }
        public String TxnreferenceNo { get; set; }
        public String BankReferenceNo { get; set; }
        public String TxnAmount { get; set; }
        public String BankID {  get; set; }
        public String BankMERCHANTID {  get; set; }
        public String TxnType {  get; set; }
        public String CurrencyName {  get; set; }
        public String ItemCode {  get; set; }
        public String SecurityType {  get; set; }
        public String SecurityID {  get; set; }
        public String SecurityPassword {  get; set; }
        public String TxnDate {  get; set; }
        public String AuthStatus {  get; set; }
        public String SettlementType {  get; set; }
        public String AdditionalInfo1 {  get; set; }
        public String AdditionalInfo2 {  get; set; }
        public String AdditionalInfo3 {  get; set; }
        public String AdditionalInfo4 {  get; set; }
        public String AdditionalInfo5 {  get; set; }
        public String AdditionalInfo6 {  get; set; }
        public String AdditionalInfo7 {  get; set; }
        public String ErrorStatus {  get; set; }
        public String ErrorDescription {  get; set; }
        public String CheckSum {  get; set; }
        public String Status { get; set; }

    }
}
