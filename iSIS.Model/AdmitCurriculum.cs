using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class AdmitCurriculum : PersistentTemporalEntity64
    {
        #region persistent
        public virtual Admission Admission { get; set; }
        public virtual ClassLevel AdmittedClassLevel { get; set; }
        [Url]
        [Required(ErrorMessage = "Application Form URL is required")]
        public virtual string ApplicationFormURL { get; set; }
        /// <summary>
        /// จำนวนนักเรียนที่จะรับ
        /// </summary>
        public virtual int Capacity { get; set; }
        /// <summary>
        /// หลักสูตรที่รับนักเรียน
        /// </summary>
        public virtual Curriculum Curriculum { get; set; }
        public virtual MultilingualString Description { get; set; }
        /// <summary>
        /// สำหรับคนในพื้นที่หรือนอกพื้นที่
        /// </summary>
        public virtual bool ForLocalPeopleOnly { get; set; }
        /// <summary>
        /// ช่วงวันจับสลาก
        /// </summary>
        public virtual DateTimeRange DrawingPeriod { get; set; }
        /// <summary>
        /// ช่วงวันมอบตัว
        /// </summary>
        public virtual DateTimeRange RegistrationPeriod { get; set; }
        /// <summary>
        /// ช่วงวันสอบ
        /// </summary>
        public virtual DateTimeRange TestPeriod { get; set; }
        /// <summary>
        /// วันประกาศผลสอบ
        /// </summary>
        public virtual DateTime TestResultPublishedDate { get; set; }
        public virtual MultilingualString Title { get; set; }

        #endregion persistent

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
        }
    }
}
