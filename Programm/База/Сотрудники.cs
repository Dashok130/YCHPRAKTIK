//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Programm.База
{
    using System;
    using System.Collections.Generic;
    
    public partial class Сотрудники
    {
        public int ID { get; set; }
        public string ФИО { get; set; }
        public string Подразделение { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string СекретноеСлово { get; set; }
        public Nullable<bool> ПравоДобавления { get; set; }
        public Nullable<bool> ПравоПросмотра { get; set; }
        public Nullable<bool> ПравоОтчётов { get; set; }
        public Nullable<bool> Одобрено { get; set; }
    }
}
