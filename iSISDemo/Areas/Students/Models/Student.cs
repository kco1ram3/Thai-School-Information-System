using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iSISDemo.Areas.Students.Models
{
    public class Student
    {
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ชื่อ")]
        public virtual string SName { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "นามสกุล")]
        public virtual string SSurname { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ชื่อเล่น")]
        public virtual string SNickname { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "เพศ")]
        public virtual string Gender { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "วัน/เดือน/ปีเกิด")]
        public virtual DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "เชื้อชาติ")]
        public virtual string Race { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "สัญชาติ")]
        public virtual string Nationality { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ศาสนา")]
        public virtual string Religion { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "สถานที่เกิด")]
        public virtual string PlaceOfBirth { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "จังหวัด")]
        public virtual string ProvinceOfBirth { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ปัจจุบันอาศัยอยู่กับ")]
        public virtual string LivingWith { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ที่อยู่เลขที่")]
        public virtual string SAddressNo { get; set; }
        [Display(Name = "หมู่")]
        public virtual string SMoo { get; set; }
        [Display(Name = "ถนน")]
        public virtual string SStreet { get; set; }
        [Display(Name = "แขวง")]
        public virtual string SSubDistrict { get; set; }
        [Display(Name = "เขต")]
        public virtual string SDistrict { get; set; }
        [Display(Name = "จังหวัด")]
        public virtual string SProvince { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "รหัสไปรษณีย์")]
        public virtual string SZipCode { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "โทร")]
        public virtual string STel { get; set; }
        [Display(Name = "การสมรสของบิดา - มารดา")]
        public virtual string MaritalStatus { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ชื่อบิดา")]
        public virtual string FName { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "นามสกุล")]
        public virtual string FSurname { get; set; }
        [Display(Name = "อายุ")]
        public virtual string FAge { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ที่อยู่เลขที่")]
        public virtual string FAddressNo { get; set; }
        [Display(Name = "หมู่")]
        public virtual string FMoo { get; set; }
        [Display(Name = "ถนน")]
        public virtual string FStreet { get; set; }
        [Display(Name = "แขวง")]
        public virtual string FSubDistrict { get; set; }
        [Display(Name = "เขต")]
        public virtual string FDistrict { get; set; }
        [Display(Name = "จังหวัด")]
        public virtual string FProvince { get; set; }
        [Display(Name = "รหัสไปรษณีย์")]
        public virtual string FZipCode { get; set; }
        [Display(Name = "โทร")]
        public virtual string FTel { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "มือถือ")]
        public virtual string FMobileTel { get; set; }
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "กรุณากรอกข้อมูลให้ถูกต้อง")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public virtual string FEmail { get; set; }
        [Display(Name = "สถานที่ทำงาน (ระบุชื่อและที่อยู่)")]
        public virtual string FOccupation { get; set; }
        [Display(Name = "เป็นกิจการเกี่ยวกับ")]
        public virtual string FBusinessType { get; set; }
        [Display(Name = "ตำแหน่ง")]
        public virtual string FPosition { get; set; }
        [Display(Name = "โทร")]
        public virtual string FOfficeTel { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ชื่อมารดา")]
        public virtual string MName { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "นามสกุล")]
        public virtual string MSurname { get; set; }
        [Display(Name = "อายุ")]
        public virtual string MAge { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ที่อยู่เลขที่")]
        public virtual string MAddressNo { get; set; }
        [Display(Name = "หมู่")]
        public virtual string MMoo { get; set; }
        [Display(Name = "ถนน")]
        public virtual string MStreet { get; set; }
        [Display(Name = "แขวง")]
        public virtual string MSubDistrict { get; set; }
        [Display(Name = "เขต")]
        public virtual string MDistrict { get; set; }
        [Display(Name = "จังหวัด")]
        public virtual string MProvince { get; set; }
        [Display(Name = "รหัสไปรษณีย์")]
        public virtual string MZipCode { get; set; }
        [Display(Name = "โทร")]
        public virtual string MTel { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "มือถือ")]
        public virtual string MMobileTel { get; set; }
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "กรุณากรอกข้อมูลให้ถูกต้อง")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public virtual string MEmail { get; set; }
        [Display(Name = "สถานที่ทำงาน (ระบุชื่อและที่อยู่)")]
        public virtual string MOccupation { get; set; }
        [Display(Name = "เป็นกิจการเกี่ยวกับ")]
        public virtual string MBusinessType { get; set; }
        [Display(Name = "ตำแหน่ง")]
        public virtual string MPosition { get; set; }
        [Display(Name = "โทร")]
        public virtual string MOfficeTel { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ชื่อผู้ปกครอง")]
        public virtual string PName { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "นามสกุล")]
        public virtual string PSurname { get; set; }
        [Display(Name = "อายุ")]
        public virtual string PAge { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ความเกี่ยวข้องกับเด็ก")]
        public virtual string PRelationship { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ที่อยู่เลขที่")]
        public virtual string PAddressNo { get; set; }
        [Display(Name = "หมู่")]
        public virtual string PMoo { get; set; }
        [Display(Name = "ถนน")]
        public virtual string PStreet { get; set; }
        [Display(Name = "แขวง")]
        public virtual string PSubDistrict { get; set; }
        [Display(Name = "เขต")]
        public virtual string PDistrict { get; set; }
        [Display(Name = "จังหวัด")]
        public virtual string PProvince { get; set; }
        [Display(Name = "รหัสไปรษณีย์")]
        public virtual string PZipCode { get; set; }
        [Display(Name = "โทร")]
        public virtual string PTel { get; set; }
        [Display(Name = "มือถือ")]
        public virtual string PMobileTel { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "หมายเลขโทรศัพท์เพื่อส่ง SMS")]
        public virtual string PTelSms { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "กรุณากรอกข้อมูลให้ถูกต้อง")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email เพื่อส่งเอกสาร")]
        public virtual string PEmailDocument { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ชื่อ-นามสกุล")]
        public virtual string CNameSurname { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "ความสัมพันธ์")]
        public virtual string CRelationship { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "สถานที่ติดต่อ")]
        public virtual string CLocation { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Display(Name = "โทร")]
        public virtual string CTel { get; set; }
    }
}