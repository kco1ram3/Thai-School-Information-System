
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9152187C7BD97B4A]') AND parent_object_id = OBJECT_ID('MLSValue'))
alter table MLSValue  drop constraint FK9152187C7BD97B4A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDFD657FE8E6F4204]') AND parent_object_id = OBJECT_ID('OrgName'))
alter table OrgName  drop constraint FKDFD657FE8E6F4204


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDFD657FE575208AB]') AND parent_object_id = OBJECT_ID('OrgName'))
alter table OrgName  drop constraint FKDFD657FE575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDFD657FE5E21BA14]') AND parent_object_id = OBJECT_ID('OrgName'))
alter table OrgName  drop constraint FKDFD657FE5E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2D1DF239F2126A14]') AND parent_object_id = OBJECT_ID('PartyAddress'))
alter table PartyAddress  drop constraint FK2D1DF239F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2D1DF239243269A7]') AND parent_object_id = OBJECT_ID('PartyAddress'))
alter table PartyAddress  drop constraint FK2D1DF239243269A7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2D1DF239C610EAE0]') AND parent_object_id = OBJECT_ID('PartyAddress'))
alter table PartyAddress  drop constraint FK2D1DF239C610EAE0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF23822D2F218E371]') AND parent_object_id = OBJECT_ID('Password'))
alter table Password  drop constraint FKF23822D2F218E371


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK19BD5E1B984D96D3]') AND parent_object_id = OBJECT_ID('PersonName'))
alter table PersonName  drop constraint FK19BD5E1B984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK19BD5E1B2E90658D]') AND parent_object_id = OBJECT_ID('PersonName'))
alter table PersonName  drop constraint FK19BD5E1B2E90658D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK19BD5E1B1CC1051E]') AND parent_object_id = OBJECT_ID('PersonName'))
alter table PersonName  drop constraint FK19BD5E1B1CC1051E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK19BD5E1B1FD87135]') AND parent_object_id = OBJECT_ID('PersonName'))
alter table PersonName  drop constraint FK19BD5E1B1FD87135


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK19BD5E1BF55E95D]') AND parent_object_id = OBJECT_ID('PersonName'))
alter table PersonName  drop constraint FK19BD5E1BF55E95D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FB23EAAB0981DE]') AND parent_object_id = OBJECT_ID('Curriculum'))
alter table Curriculum  drop constraint FK4FB23EAAB0981DE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FB23EAA673FC9A1]') AND parent_object_id = OBJECT_ID('Curriculum'))
alter table Curriculum  drop constraint FK4FB23EAA673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FB23EAA12A6D31A]') AND parent_object_id = OBJECT_ID('Curriculum'))
alter table Curriculum  drop constraint FK4FB23EAA12A6D31A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FB23EAA234B5126]') AND parent_object_id = OBJECT_ID('Curriculum'))
alter table Curriculum  drop constraint FK4FB23EAA234B5126


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FB23EAA575208AB]') AND parent_object_id = OBJECT_ID('Curriculum'))
alter table Curriculum  drop constraint FK4FB23EAA575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FB23EAA5E21BA14]') AND parent_object_id = OBJECT_ID('Curriculum'))
alter table Curriculum  drop constraint FK4FB23EAA5E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52CE2211575208AB]') AND parent_object_id = OBJECT_ID('DesiredOutcome'))
alter table DesiredOutcome  drop constraint FK52CE2211575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52CE22115E21BA14]') AND parent_object_id = OBJECT_ID('DesiredOutcome'))
alter table DesiredOutcome  drop constraint FK52CE22115E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52CE2211B0981DE]') AND parent_object_id = OBJECT_ID('DesiredOutcome'))
alter table DesiredOutcome  drop constraint FK52CE2211B0981DE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52CE2211696C8972]') AND parent_object_id = OBJECT_ID('DesiredOutcome'))
alter table DesiredOutcome  drop constraint FK52CE2211696C8972


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52CE2211FF5D6B2A]') AND parent_object_id = OBJECT_ID('DesiredOutcome'))
alter table DesiredOutcome  drop constraint FK52CE2211FF5D6B2A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52CE2211DF83CA9E]') AND parent_object_id = OBJECT_ID('DesiredOutcome'))
alter table DesiredOutcome  drop constraint FK52CE2211DF83CA9E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK74ACBA10F2126A14]') AND parent_object_id = OBJECT_ID('ClassLevel'))
alter table ClassLevel  drop constraint FK74ACBA10F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK74ACBA105E21BA14]') AND parent_object_id = OBJECT_ID('ClassLevel'))
alter table ClassLevel  drop constraint FK74ACBA105E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK74ACBA10575208AB]') AND parent_object_id = OBJECT_ID('ClassLevel'))
alter table ClassLevel  drop constraint FK74ACBA10575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFFF43403C11127A8]') AND parent_object_id = OBJECT_ID('Course'))
alter table Course  drop constraint FKFFF43403C11127A8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFFF43403345C57B0]') AND parent_object_id = OBJECT_ID('Course'))
alter table Course  drop constraint FKFFF43403345C57B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFFF43403575208AB]') AND parent_object_id = OBJECT_ID('Course'))
alter table Course  drop constraint FKFFF43403575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFFF434035E21BA14]') AND parent_object_id = OBJECT_ID('Course'))
alter table Course  drop constraint FKFFF434035E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFFF43403DF83CA9E]') AND parent_object_id = OBJECT_ID('Course'))
alter table Course  drop constraint FKFFF43403DF83CA9E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFFF43403600E2A93]') AND parent_object_id = OBJECT_ID('Course'))
alter table Course  drop constraint FKFFF43403600E2A93


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFFF43403A685EF61]') AND parent_object_id = OBJECT_ID('Course'))
alter table Course  drop constraint FKFFF43403A685EF61


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFFF43403673FC9A1]') AND parent_object_id = OBJECT_ID('Course'))
alter table Course  drop constraint FKFFF43403673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK73C798CB345C57B0]') AND parent_object_id = OBJECT_ID('PerformanceIndicator'))
alter table PerformanceIndicator  drop constraint FK73C798CB345C57B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK73C798CBDF83CA9E]') AND parent_object_id = OBJECT_ID('PerformanceIndicator'))
alter table PerformanceIndicator  drop constraint FK73C798CBDF83CA9E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK73C798CBC597107D]') AND parent_object_id = OBJECT_ID('PerformanceIndicator'))
alter table PerformanceIndicator  drop constraint FK73C798CBC597107D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9BDA06707B543F88]') AND parent_object_id = OBJECT_ID('GeographicAddress'))
alter table GeographicAddress  drop constraint FK9BDA06707B543F88


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9BDA06702B441BF5]') AND parent_object_id = OBJECT_ID('GeographicAddress'))
alter table GeographicAddress  drop constraint FK9BDA06702B441BF5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9BDA067054D213FE]') AND parent_object_id = OBJECT_ID('GeographicAddress'))
alter table GeographicAddress  drop constraint FK9BDA067054D213FE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9BDA06706A58440B]') AND parent_object_id = OBJECT_ID('GeographicAddress'))
alter table GeographicAddress  drop constraint FK9BDA06706A58440B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9BDA0670D92DBFB9]') AND parent_object_id = OBJECT_ID('GeographicAddress'))
alter table GeographicAddress  drop constraint FK9BDA0670D92DBFB9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9BDA0670CAD380C]') AND parent_object_id = OBJECT_ID('GeographicAddress'))
alter table GeographicAddress  drop constraint FK9BDA0670CAD380C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9BDA06706E7B1A37]') AND parent_object_id = OBJECT_ID('GeographicAddress'))
alter table GeographicAddress  drop constraint FK9BDA06706E7B1A37


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9BDA06701ABADAEC]') AND parent_object_id = OBJECT_ID('GeographicAddress'))
alter table GeographicAddress  drop constraint FK9BDA06701ABADAEC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK85167F821ABADAEC]') AND parent_object_id = OBJECT_ID('GeographicRegion'))
alter table GeographicRegion  drop constraint FK85167F821ABADAEC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK85167F828E14B6EA]') AND parent_object_id = OBJECT_ID('GeographicRegion'))
alter table GeographicRegion  drop constraint FK85167F828E14B6EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK85167F82575208AB]') AND parent_object_id = OBJECT_ID('GeographicRegion'))
alter table GeographicRegion  drop constraint FK85167F82575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C55D8ABA8D7C5AF]') AND parent_object_id = OBJECT_ID('Person'))
alter table Person  drop constraint FK8C55D8ABA8D7C5AF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C55D8ABD6F2F02B]') AND parent_object_id = OBJECT_ID('Person'))
alter table Person  drop constraint FK8C55D8ABD6F2F02B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C55D8AB29DD5C57]') AND parent_object_id = OBJECT_ID('Person'))
alter table Person  drop constraint FK8C55D8AB29DD5C57


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C55D8AB7A3270FF]') AND parent_object_id = OBJECT_ID('Person'))
alter table Person  drop constraint FK8C55D8AB7A3270FF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C55D8AB62058B43]') AND parent_object_id = OBJECT_ID('Person'))
alter table Person  drop constraint FK8C55D8AB62058B43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C55D8AB9AB70F08]') AND parent_object_id = OBJECT_ID('Person'))
alter table Person  drop constraint FK8C55D8AB9AB70F08


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C55D8AB73F728E8]') AND parent_object_id = OBJECT_ID('Person'))
alter table Person  drop constraint FK8C55D8AB73F728E8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35E813F575208AB]') AND parent_object_id = OBJECT_ID('HierarchicalCategory'))
alter table HierarchicalCategory  drop constraint FK35E813F575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35E813F345C57B0]') AND parent_object_id = OBJECT_ID('HierarchicalCategory'))
alter table HierarchicalCategory  drop constraint FK35E813F345C57B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35E813F5E21BA14]') AND parent_object_id = OBJECT_ID('HierarchicalCategory'))
alter table HierarchicalCategory  drop constraint FK35E813F5E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35E813F55DE22B4]') AND parent_object_id = OBJECT_ID('HierarchicalCategory'))
alter table HierarchicalCategory  drop constraint FK35E813F55DE22B4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35E813F4A8C2AD3]') AND parent_object_id = OBJECT_ID('HierarchicalCategory'))
alter table HierarchicalCategory  drop constraint FK35E813F4A8C2AD3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK331D9CC5F2126A14]') AND parent_object_id = OBJECT_ID('PartyIdentity'))
alter table PartyIdentity  drop constraint FK331D9CC5F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK331D9CC56B1B0DAD]') AND parent_object_id = OBJECT_ID('PartyIdentity'))
alter table PartyIdentity  drop constraint FK331D9CC56B1B0DAD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK331D9CC5C610EAE0]') AND parent_object_id = OBJECT_ID('PartyIdentity'))
alter table PartyIdentity  drop constraint FK331D9CC5C610EAE0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2ABF29C3575208AB]') AND parent_object_id = OBJECT_ID('Country'))
alter table Country  drop constraint FK2ABF29C3575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK50043DF2673FC9A1]') AND parent_object_id = OBJECT_ID('Semester'))
alter table Semester  drop constraint FK50043DF2673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9836A5BBDF83CA9E]') AND parent_object_id = OBJECT_ID('ClassLevelSection'))
alter table ClassLevelSection  drop constraint FK9836A5BBDF83CA9E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9836A5BB673FC9A1]') AND parent_object_id = OBJECT_ID('ClassLevelSection'))
alter table ClassLevelSection  drop constraint FK9836A5BB673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9836A5BBB06A8A23]') AND parent_object_id = OBJECT_ID('ClassLevelSection'))
alter table ClassLevelSection  drop constraint FK9836A5BBB06A8A23


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9836A5BB575208AB]') AND parent_object_id = OBJECT_ID('ClassLevelSection'))
alter table ClassLevelSection  drop constraint FK9836A5BB575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9836A5BB5E21BA14]') AND parent_object_id = OBJECT_ID('ClassLevelSection'))
alter table ClassLevelSection  drop constraint FK9836A5BB5E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK67804DA4F3CC5328]') AND parent_object_id = OBJECT_ID('[User]'))
alter table [User]  drop constraint FK67804DA4F3CC5328


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK67804DA48E6F4204]') AND parent_object_id = OBJECT_ID('[User]'))
alter table [User]  drop constraint FK67804DA48E6F4204


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK67804DA4984D96D3]') AND parent_object_id = OBJECT_ID('[User]'))
alter table [User]  drop constraint FK67804DA4984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK67804DA4FAE3254F]') AND parent_object_id = OBJECT_ID('[User]'))
alter table [User]  drop constraint FK67804DA4FAE3254F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA43605DD673FC9A1]') AND parent_object_id = OBJECT_ID('Room'))
alter table Room  drop constraint FKA43605DD673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA43605DD55DE9358]') AND parent_object_id = OBJECT_ID('Room'))
alter table Room  drop constraint FKA43605DD55DE9358


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK882079A7F2126A14]') AND parent_object_id = OBJECT_ID('Teacher'))
alter table Teacher  drop constraint FK882079A7F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK882079A7673FC9A1]') AND parent_object_id = OBJECT_ID('Teacher'))
alter table Teacher  drop constraint FK882079A7673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK882079A7984D96D3]') AND parent_object_id = OBJECT_ID('Teacher'))
alter table Teacher  drop constraint FK882079A7984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK882079A776E3D8D6]') AND parent_object_id = OBJECT_ID('Teacher'))
alter table Teacher  drop constraint FK882079A776E3D8D6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK882079A7786F1B8E]') AND parent_object_id = OBJECT_ID('Teacher'))
alter table Teacher  drop constraint FK882079A7786F1B8E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK55BC43D3495E2B7F]') AND parent_object_id = OBJECT_ID('CourseSection'))
alter table CourseSection  drop constraint FK55BC43D3495E2B7F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK55BC43D3B06A8A23]') AND parent_object_id = OBJECT_ID('CourseSection'))
alter table CourseSection  drop constraint FK55BC43D3B06A8A23


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK55BC43D3BFF4F5D]') AND parent_object_id = OBJECT_ID('CourseSection'))
alter table CourseSection  drop constraint FK55BC43D3BFF4F5D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK55BC43D3B7D0928F]') AND parent_object_id = OBJECT_ID('CourseSection'))
alter table CourseSection  drop constraint FK55BC43D3B7D0928F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK55BC43D3673FC9A1]') AND parent_object_id = OBJECT_ID('CourseSection'))
alter table CourseSection  drop constraint FK55BC43D3673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK732A69A262192F31]') AND parent_object_id = OBJECT_ID('ClassroomStudent'))
alter table ClassroomStudent  drop constraint FK732A69A262192F31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK732A69A2BF91423D]') AND parent_object_id = OBJECT_ID('ClassroomStudent'))
alter table ClassroomStudent  drop constraint FK732A69A2BF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAC4A75BABFF4F5D]') AND parent_object_id = OBJECT_ID('Classroom'))
alter table Classroom  drop constraint FKAC4A75BABFF4F5D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAC4A75BAB7D0928F]') AND parent_object_id = OBJECT_ID('Classroom'))
alter table Classroom  drop constraint FKAC4A75BAB7D0928F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAC4A75BA673FC9A1]') AND parent_object_id = OBJECT_ID('Classroom'))
alter table Classroom  drop constraint FKAC4A75BA673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAC4A75BAB06A8A23]') AND parent_object_id = OBJECT_ID('Classroom'))
alter table Classroom  drop constraint FKAC4A75BAB06A8A23


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDC8285D9F2126A14]') AND parent_object_id = OBJECT_ID('ClassroomTeacher'))
alter table ClassroomTeacher  drop constraint FKDC8285D9F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDC8285D962192F31]') AND parent_object_id = OBJECT_ID('ClassroomTeacher'))
alter table ClassroomTeacher  drop constraint FKDC8285D962192F31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDC8285D968C475E0]') AND parent_object_id = OBJECT_ID('ClassroomTeacher'))
alter table ClassroomTeacher  drop constraint FKDC8285D968C475E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC2C0BEA7256CF10]') AND parent_object_id = OBJECT_ID('CourseSectionStudent'))
alter table CourseSectionStudent  drop constraint FKC2C0BEA7256CF10


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC2C0BEA7BF91423D]') AND parent_object_id = OBJECT_ID('CourseSectionStudent'))
alter table CourseSectionStudent  drop constraint FKC2C0BEA7BF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC2C0BEA7F6BF02B1]') AND parent_object_id = OBJECT_ID('CourseSectionStudent'))
alter table CourseSectionStudent  drop constraint FKC2C0BEA7F6BF02B1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7B762B8256CF10]') AND parent_object_id = OBJECT_ID('CourseSectionTeacher'))
alter table CourseSectionTeacher  drop constraint FK7B762B8256CF10


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7B762B868C475E0]') AND parent_object_id = OBJECT_ID('CourseSectionTeacher'))
alter table CourseSectionTeacher  drop constraint FK7B762B868C475E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK26516C66256CF10]') AND parent_object_id = OBJECT_ID('PerformanceMeasurement'))
alter table PerformanceMeasurement  drop constraint FK26516C66256CF10


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK26516C66E867AF38]') AND parent_object_id = OBJECT_ID('PerformanceMeasurement'))
alter table PerformanceMeasurement  drop constraint FK26516C66E867AF38


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK26516C66B06A8A23]') AND parent_object_id = OBJECT_ID('PerformanceMeasurement'))
alter table PerformanceMeasurement  drop constraint FK26516C66B06A8A23


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK26516C66BF91423D]') AND parent_object_id = OBJECT_ID('PerformanceMeasurement'))
alter table PerformanceMeasurement  drop constraint FK26516C66BF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK180A7094575208AB]') AND parent_object_id = OBJECT_ID('GradingSystem'))
alter table GradingSystem  drop constraint FK180A7094575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK180A70945E21BA14]') AND parent_object_id = OBJECT_ID('GradingSystem'))
alter table GradingSystem  drop constraint FK180A70945E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK765D4B60CBB71C77]') AND parent_object_id = OBJECT_ID('DiscreteGrade'))
alter table DiscreteGrade  drop constraint FK765D4B60CBB71C77


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EE628FBF2126A14]') AND parent_object_id = OBJECT_ID('Student'))
alter table Student  drop constraint FK5EE628FBF2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EE628FB673FC9A1]') AND parent_object_id = OBJECT_ID('Student'))
alter table Student  drop constraint FK5EE628FB673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EE628FB984D96D3]') AND parent_object_id = OBJECT_ID('Student'))
alter table Student  drop constraint FK5EE628FB984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EE628FB25A7976B]') AND parent_object_id = OBJECT_ID('Student'))
alter table Student  drop constraint FK5EE628FB25A7976B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EE628FB76E3D8D6]') AND parent_object_id = OBJECT_ID('Student'))
alter table Student  drop constraint FK5EE628FB76E3D8D6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EE628FB848293A8]') AND parent_object_id = OBJECT_ID('Student'))
alter table Student  drop constraint FK5EE628FB848293A8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5EE628FB786F1B8E]') AND parent_object_id = OBJECT_ID('Student'))
alter table Student  drop constraint FK5EE628FB786F1B8E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD5CC1243575208AB]') AND parent_object_id = OBJECT_ID('CurriculumFramework'))
alter table CurriculumFramework  drop constraint FKD5CC1243575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD5CC12435E21BA14]') AND parent_object_id = OBJECT_ID('CurriculumFramework'))
alter table CurriculumFramework  drop constraint FKD5CC12435E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF47C10F5F2126A14]') AND parent_object_id = OBJECT_ID('CurriculumCourse'))
alter table CurriculumCourse  drop constraint FKF47C10F5F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF47C10F5495E2B7F]') AND parent_object_id = OBJECT_ID('CurriculumCourse'))
alter table CurriculumCourse  drop constraint FKF47C10F5495E2B7F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF47C10F549E5D649]') AND parent_object_id = OBJECT_ID('CurriculumCourse'))
alter table CurriculumCourse  drop constraint FKF47C10F549E5D649


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF47C10F55BE10676]') AND parent_object_id = OBJECT_ID('CurriculumCourse'))
alter table CurriculumCourse  drop constraint FKF47C10F55BE10676


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK297C0BDEF218E371]') AND parent_object_id = OBJECT_ID('UserRole'))
alter table UserRole  drop constraint FK297C0BDEF218E371


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK297C0BDE7EBC4621]') AND parent_object_id = OBJECT_ID('UserRole'))
alter table UserRole  drop constraint FK297C0BDE7EBC4621


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADEBC81F345C57B0]') AND parent_object_id = OBJECT_ID('Admission'))
alter table Admission  drop constraint FKADEBC81F345C57B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADEBC81FB06A8A23]') AND parent_object_id = OBJECT_ID('Admission'))
alter table Admission  drop constraint FKADEBC81FB06A8A23


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADEBC81F673FC9A1]') AND parent_object_id = OBJECT_ID('Admission'))
alter table Admission  drop constraint FKADEBC81F673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADEBC81F8D31B83F]') AND parent_object_id = OBJECT_ID('Admission'))
alter table Admission  drop constraint FKADEBC81F8D31B83F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADEBC81F24EB43E5]') AND parent_object_id = OBJECT_ID('Admission'))
alter table Admission  drop constraint FKADEBC81F24EB43E5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK38F9836B8A9FF62A]') AND parent_object_id = OBJECT_ID('AdmissionTest'))
alter table AdmissionTest  drop constraint FK38F9836B8A9FF62A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK26A94C9B6C1A03A7]') AND parent_object_id = OBJECT_ID('TestScore'))
alter table TestScore  drop constraint FK26A94C9B6C1A03A7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK26A94C9BA80C643D]') AND parent_object_id = OBJECT_ID('TestScore'))
alter table TestScore  drop constraint FK26A94C9BA80C643D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8E8A9FF62A]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8E8A9FF62A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8EF24A603B]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8EF24A603B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8E3393F897]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8E3393F897


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8E5BBA57AD]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8E5BBA57AD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8E8F0379E5]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8E8F0379E5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8E5BF459FA]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8E5BF459FA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8EFE633CCD]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8EFE633CCD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8EA4F489C8]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8EA4F489C8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51C08A8E9050CA29]') AND parent_object_id = OBJECT_ID('StudentApplication'))
alter table StudentApplication  drop constraint FK51C08A8E9050CA29


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52C460318A9FF62A]') AND parent_object_id = OBJECT_ID('AdmitCurriculum'))
alter table AdmitCurriculum  drop constraint FK52C460318A9FF62A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52C46031848293A8]') AND parent_object_id = OBJECT_ID('AdmitCurriculum'))
alter table AdmitCurriculum  drop constraint FK52C46031848293A8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK52C4603149E5D649]') AND parent_object_id = OBJECT_ID('AdmitCurriculum'))
alter table AdmitCurriculum  drop constraint FK52C4603149E5D649


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK91319BFCA80C643D]') AND parent_object_id = OBJECT_ID('AlternateSchool'))
alter table AlternateSchool  drop constraint FK91319BFCA80C643D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK91319BFC673FC9A1]') AND parent_object_id = OBJECT_ID('AlternateSchool'))
alter table AlternateSchool  drop constraint FK91319BFC673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK513A3A7DF2126A14]') AND parent_object_id = OBJECT_ID('Absence'))
alter table Absence  drop constraint FK513A3A7DF2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK513A3A7DBF91423D]') AND parent_object_id = OBJECT_ID('Absence'))
alter table Absence  drop constraint FK513A3A7DBF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK513A3A7D256CF10]') AND parent_object_id = OBJECT_ID('Absence'))
alter table Absence  drop constraint FK513A3A7D256CF10


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC23A5F1CBFE8DFC]') AND parent_object_id = OBJECT_ID('Punishment'))
alter table Punishment  drop constraint FKC23A5F1CBFE8DFC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC23A5F1CB226B37B]') AND parent_object_id = OBJECT_ID('Punishment'))
alter table Punishment  drop constraint FKC23A5F1CB226B37B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC23A5F1CBF91423D]') AND parent_object_id = OBJECT_ID('Punishment'))
alter table Punishment  drop constraint FKC23A5F1CBF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1A1B2009F2126A14]') AND parent_object_id = OBJECT_ID('Reward'))
alter table Reward  drop constraint FK1A1B2009F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1A1B2009BF91423D]') AND parent_object_id = OBJECT_ID('Reward'))
alter table Reward  drop constraint FK1A1B2009BF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA0E487B7DF83CA9E]') AND parent_object_id = OBJECT_ID('StudentSemester'))
alter table StudentSemester  drop constraint FKA0E487B7DF83CA9E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA0E487B7B06A8A23]') AND parent_object_id = OBJECT_ID('StudentSemester'))
alter table StudentSemester  drop constraint FKA0E487B7B06A8A23


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA0E487B7BF91423D]') AND parent_object_id = OBJECT_ID('StudentSemester'))
alter table StudentSemester  drop constraint FKA0E487B7BF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA0E487B7673FC9A1]') AND parent_object_id = OBJECT_ID('StudentSemester'))
alter table StudentSemester  drop constraint FKA0E487B7673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4E0D2B45DF83CA9E]') AND parent_object_id = OBJECT_ID('StudentAcademicYear'))
alter table StudentAcademicYear  drop constraint FK4E0D2B45DF83CA9E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4E0D2B45BF91423D]') AND parent_object_id = OBJECT_ID('StudentAcademicYear'))
alter table StudentAcademicYear  drop constraint FK4E0D2B45BF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4E0D2B45673FC9A1]') AND parent_object_id = OBJECT_ID('StudentAcademicYear'))
alter table StudentAcademicYear  drop constraint FK4E0D2B45673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK44C0C48A984D96D3]') AND parent_object_id = OBJECT_ID('Photo'))
alter table Photo  drop constraint FK44C0C48A984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEDFA4DA862D9F043]') AND parent_object_id = OBJECT_ID('RoyalDecoration'))
alter table RoyalDecoration  drop constraint FKEDFA4DA862D9F043


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEDFA4DA8984D96D3]') AND parent_object_id = OBJECT_ID('RoyalDecoration'))
alter table RoyalDecoration  drop constraint FKEDFA4DA8984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA29C30D984D96D3]') AND parent_object_id = OBJECT_ID('Education'))
alter table Education  drop constraint FKA29C30D984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA29C30D255568BC]') AND parent_object_id = OBJECT_ID('Education'))
alter table Education  drop constraint FKA29C30D255568BC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK85E4D6C3984D96D3]') AND parent_object_id = OBJECT_ID('Experience'))
alter table Experience  drop constraint FK85E4D6C3984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK85E4D6C38E6F4204]') AND parent_object_id = OBJECT_ID('Experience'))
alter table Experience  drop constraint FK85E4D6C38E6F4204


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3223B02F984D96D3]') AND parent_object_id = OBJECT_ID('AcademicAchievement'))
alter table AcademicAchievement  drop constraint FK3223B02F984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3223B02FE867AF38]') AND parent_object_id = OBJECT_ID('AcademicAchievement'))
alter table AcademicAchievement  drop constraint FK3223B02FE867AF38


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF8A10617984D96D3]') AND parent_object_id = OBJECT_ID('AcademicEventParticipation'))
alter table AcademicEventParticipation  drop constraint FKF8A10617984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF8A106178354F09E]') AND parent_object_id = OBJECT_ID('AcademicEventParticipation'))
alter table AcademicEventParticipation  drop constraint FKF8A106178354F09E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6117A80CF3CC5328]') AND parent_object_id = OBJECT_ID('Role'))
alter table Role  drop constraint FK6117A80CF3CC5328


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6117A80C345C57B0]') AND parent_object_id = OBJECT_ID('Role'))
alter table Role  drop constraint FK6117A80C345C57B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6117A80C5E21BA14]') AND parent_object_id = OBJECT_ID('Role'))
alter table Role  drop constraint FK6117A80C5E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6117A80C575208AB]') AND parent_object_id = OBJECT_ID('Role'))
alter table Role  drop constraint FK6117A80C575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6AF3367D575208AB]') AND parent_object_id = OBJECT_ID('Application'))
alter table Application  drop constraint FK6AF3367D575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6AF3367D5E21BA14]') AND parent_object_id = OBJECT_ID('Application'))
alter table Application  drop constraint FK6AF3367D5E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC8A5EA4DB9423D9]') AND parent_object_id = OBJECT_ID('AdmissionTestRoom'))
alter table AdmissionTestRoom  drop constraint FKC8A5EA4DB9423D9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC8A5EA4D8A9FF62A]') AND parent_object_id = OBJECT_ID('AdmissionTestRoom'))
alter table AdmissionTestRoom  drop constraint FKC8A5EA4D8A9FF62A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9920B579F2126A14]') AND parent_object_id = OBJECT_ID('SchoolAdministrator'))
alter table SchoolAdministrator  drop constraint FK9920B579F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9920B579673FC9A1]') AND parent_object_id = OBJECT_ID('SchoolAdministrator'))
alter table SchoolAdministrator  drop constraint FK9920B579673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9920B579984D96D3]') AND parent_object_id = OBJECT_ID('SchoolAdministrator'))
alter table SchoolAdministrator  drop constraint FK9920B579984D96D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9920B57976E3D8D6]') AND parent_object_id = OBJECT_ID('SchoolAdministrator'))
alter table SchoolAdministrator  drop constraint FK9920B57976E3D8D6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE2653A8B06A8A23]') AND parent_object_id = OBJECT_ID('Receipt'))
alter table Receipt  drop constraint FKEE2653A8B06A8A23


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE2653A8673FC9A1]') AND parent_object_id = OBJECT_ID('Receipt'))
alter table Receipt  drop constraint FKEE2653A8673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE2653A8BF91423D]') AND parent_object_id = OBJECT_ID('Receipt'))
alter table Receipt  drop constraint FKEE2653A8BF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE86169E9930578D0]') AND parent_object_id = OBJECT_ID('ReceiptItem'))
alter table ReceiptItem  drop constraint FKE86169E9930578D0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE86169E937865257]') AND parent_object_id = OBJECT_ID('ReceiptItem'))
alter table ReceiptItem  drop constraint FKE86169E937865257


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK686D76F4673FC9A1]') AND parent_object_id = OBJECT_ID('ReceiptTemplate'))
alter table ReceiptTemplate  drop constraint FK686D76F4673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK57AFC1B7227CB706]') AND parent_object_id = OBJECT_ID('ReceiptTemplateItem'))
alter table ReceiptTemplateItem  drop constraint FK57AFC1B7227CB706


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK57AFC1B737865257]') AND parent_object_id = OBJECT_ID('ReceiptTemplateItem'))
alter table ReceiptTemplateItem  drop constraint FK57AFC1B737865257


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1288F4B4673FC9A1]') AND parent_object_id = OBJECT_ID('ReceivableItem'))
alter table ReceivableItem  drop constraint FK1288F4B4673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1288F4B4575208AB]') AND parent_object_id = OBJECT_ID('ReceivableItem'))
alter table ReceivableItem  drop constraint FK1288F4B4575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE955A37B06A8A23]') AND parent_object_id = OBJECT_ID('Register'))
alter table Register  drop constraint FKEE955A37B06A8A23


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE955A37673FC9A1]') AND parent_object_id = OBJECT_ID('Register'))
alter table Register  drop constraint FKEE955A37673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE955A37F218E371]') AND parent_object_id = OBJECT_ID('Register'))
alter table Register  drop constraint FKEE955A37F218E371


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB66FB4859DD9B2B]') AND parent_object_id = OBJECT_ID('RegisterDetail'))
alter table RegisterDetail  drop constraint FKB66FB4859DD9B2B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB66FB48549E5D649]') AND parent_object_id = OBJECT_ID('RegisterDetail'))
alter table RegisterDetail  drop constraint FKB66FB48549E5D649


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB66FB485BF91423D]') AND parent_object_id = OBJECT_ID('RegisterDetail'))
alter table RegisterDetail  drop constraint FKB66FB485BF91423D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB66FB48568C475E0]') AND parent_object_id = OBJECT_ID('RegisterDetail'))
alter table RegisterDetail  drop constraint FKB66FB48568C475E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C83F6B37EDD26E9]') AND parent_object_id = OBJECT_ID('RegisterPayment'))
alter table RegisterPayment  drop constraint FK2C83F6B37EDD26E9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C83F6B3495E2B7F]') AND parent_object_id = OBJECT_ID('RegisterPayment'))
alter table RegisterPayment  drop constraint FK2C83F6B3495E2B7F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C83F6B3F218E371]') AND parent_object_id = OBJECT_ID('RegisterPayment'))
alter table RegisterPayment  drop constraint FK2C83F6B3F218E371


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBEF9D81892B22A1F]') AND parent_object_id = OBJECT_ID('Screen'))
alter table Screen  drop constraint FKBEF9D81892B22A1F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBEF9D818575208AB]') AND parent_object_id = OBJECT_ID('Screen'))
alter table Screen  drop constraint FKBEF9D818575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBEF9D8189BE14FB9]') AND parent_object_id = OBJECT_ID('Screen'))
alter table Screen  drop constraint FKBEF9D8189BE14FB9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE5950A3B575208AB]') AND parent_object_id = OBJECT_ID('Module'))
alter table Module  drop constraint FKE5950A3B575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE5950A3BA0E84C0E]') AND parent_object_id = OBJECT_ID('Module'))
alter table Module  drop constraint FKE5950A3BA0E84C0E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF16ED1EE50A49727]') AND parent_object_id = OBJECT_ID('CourseSectionPerformance'))
alter table CourseSectionPerformance  drop constraint FKF16ED1EE50A49727


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF16ED1EE798D4E3D]') AND parent_object_id = OBJECT_ID('CourseSectionPerformance'))
alter table CourseSectionPerformance  drop constraint FKF16ED1EE798D4E3D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK712BFBFB256CF10]') AND parent_object_id = OBJECT_ID('CourseSectionAppraisal'))
alter table CourseSectionAppraisal  drop constraint FK712BFBFB256CF10


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK712BFBFB345C57B0]') AND parent_object_id = OBJECT_ID('CourseSectionAppraisal'))
alter table CourseSectionAppraisal  drop constraint FK712BFBFB345C57B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK712BFBFB575208AB]') AND parent_object_id = OBJECT_ID('CourseSectionAppraisal'))
alter table CourseSectionAppraisal  drop constraint FK712BFBFB575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBFCF8D8E6F4204]') AND parent_object_id = OBJECT_ID('ChartOfAccount'))
alter table ChartOfAccount  drop constraint FKCBFCF8D8E6F4204


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBFCF8D1B3389C9]') AND parent_object_id = OBJECT_ID('ChartOfAccount'))
alter table ChartOfAccount  drop constraint FKCBFCF8D1B3389C9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBFCF8DFF2A98A3]') AND parent_object_id = OBJECT_ID('ChartOfAccount'))
alter table ChartOfAccount  drop constraint FKCBFCF8DFF2A98A3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBFCF8D5E21BA14]') AND parent_object_id = OBJECT_ID('ChartOfAccount'))
alter table ChartOfAccount  drop constraint FKCBFCF8D5E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBFCF8D575208AB]') AND parent_object_id = OBJECT_ID('ChartOfAccount'))
alter table ChartOfAccount  drop constraint FKCBFCF8D575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBFCF8DEA99F1CB]') AND parent_object_id = OBJECT_ID('ChartOfAccount'))
alter table ChartOfAccount  drop constraint FKCBFCF8DEA99F1CB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7D893182A1FBAB9]') AND parent_object_id = OBJECT_ID('Organization'))
alter table Organization  drop constraint FKA7D893182A1FBAB9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7D89318F2126A14]') AND parent_object_id = OBJECT_ID('Organization'))
alter table Organization  drop constraint FKA7D89318F2126A14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7D893187DFC9CCC]') AND parent_object_id = OBJECT_ID('Organization'))
alter table Organization  drop constraint FKA7D893187DFC9CCC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7D89318DD469D20]') AND parent_object_id = OBJECT_ID('Organization'))
alter table Organization  drop constraint FKA7D89318DD469D20


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7D8931848CB873A]') AND parent_object_id = OBJECT_ID('Organization'))
alter table Organization  drop constraint FKA7D8931848CB873A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7D8931895F30284]') AND parent_object_id = OBJECT_ID('Organization'))
alter table Organization  drop constraint FKA7D8931895F30284


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK182C0A138E6F4204]') AND parent_object_id = OBJECT_ID('Ledger'))
alter table Ledger  drop constraint FK182C0A138E6F4204


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK182C0A135E21BA14]') AND parent_object_id = OBJECT_ID('Ledger'))
alter table Ledger  drop constraint FK182C0A135E21BA14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK182C0A13575208AB]') AND parent_object_id = OBJECT_ID('Ledger'))
alter table Ledger  drop constraint FK182C0A13575208AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35C99074D98FC089]') AND parent_object_id = OBJECT_ID('JournalEntry'))
alter table JournalEntry  drop constraint FK35C99074D98FC089


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35C9907443EA2DCA]') AND parent_object_id = OBJECT_ID('JournalEntry'))
alter table JournalEntry  drop constraint FK35C9907443EA2DCA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35C99074A5695FA8]') AND parent_object_id = OBJECT_ID('JournalEntry'))
alter table JournalEntry  drop constraint FK35C99074A5695FA8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE062BA8D5A650E7E]') AND parent_object_id = OBJECT_ID('AccountingTransaction'))
alter table AccountingTransaction  drop constraint FKE062BA8D5A650E7E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK11904ED8D98FC089]') AND parent_object_id = OBJECT_ID('AccountingPeriod'))
alter table AccountingPeriod  drop constraint FK11904ED8D98FC089


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9196DB3D8E6F4204]') AND parent_object_id = OBJECT_ID('AuthorizeModule'))
alter table AuthorizeModule  drop constraint FK9196DB3D8E6F4204


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9196DB3D7EBC4621]') AND parent_object_id = OBJECT_ID('AuthorizeModule'))
alter table AuthorizeModule  drop constraint FK9196DB3D7EBC4621


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9196DB3D92B22A1F]') AND parent_object_id = OBJECT_ID('AuthorizeModule'))
alter table AuthorizeModule  drop constraint FK9196DB3D92B22A1F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK90D5D95A8E6F4204]') AND parent_object_id = OBJECT_ID('AuthorizeScreen'))
alter table AuthorizeScreen  drop constraint FK90D5D95A8E6F4204


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK90D5D95A7EBC4621]') AND parent_object_id = OBJECT_ID('AuthorizeScreen'))
alter table AuthorizeScreen  drop constraint FK90D5D95A7EBC4621


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK90D5D95A9B354ECD]') AND parent_object_id = OBJECT_ID('AuthorizeScreen'))
alter table AuthorizeScreen  drop constraint FK90D5D95A9B354ECD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC0EDF055673FC9A1]') AND parent_object_id = OBJECT_ID('AutomaticGrading'))
alter table AutomaticGrading  drop constraint FKC0EDF055673FC9A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC0EDF055669A7B88]') AND parent_object_id = OBJECT_ID('AutomaticGrading'))
alter table AutomaticGrading  drop constraint FKC0EDF055669A7B88


    if exists (select * from dbo.sysobjects where id = object_id(N'Language') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Language

    if exists (select * from dbo.sysobjects where id = object_id(N'MLSValue') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MLSValue

    if exists (select * from dbo.sysobjects where id = object_id(N'MultilingualString') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table MultilingualString

    if exists (select * from dbo.sysobjects where id = object_id(N'OrgName') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table OrgName

    if exists (select * from dbo.sysobjects where id = object_id(N'PartyAddress') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PartyAddress

    if exists (select * from dbo.sysobjects where id = object_id(N'Password') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Password

    if exists (select * from dbo.sysobjects where id = object_id(N'PersonName') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PersonName

    if exists (select * from dbo.sysobjects where id = object_id(N'Curriculum') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Curriculum

    if exists (select * from dbo.sysobjects where id = object_id(N'DesiredOutcome') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table DesiredOutcome

    if exists (select * from dbo.sysobjects where id = object_id(N'ClassLevel') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ClassLevel

    if exists (select * from dbo.sysobjects where id = object_id(N'Course') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Course

    if exists (select * from dbo.sysobjects where id = object_id(N'PerformanceIndicator') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PerformanceIndicator

    if exists (select * from dbo.sysobjects where id = object_id(N'GeographicAddress') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GeographicAddress

    if exists (select * from dbo.sysobjects where id = object_id(N'GeographicRegion') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GeographicRegion

    if exists (select * from dbo.sysobjects where id = object_id(N'Person') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Person

    if exists (select * from dbo.sysobjects where id = object_id(N'HierarchicalCategory') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table HierarchicalCategory

    if exists (select * from dbo.sysobjects where id = object_id(N'PartyIdentity') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PartyIdentity

    if exists (select * from dbo.sysobjects where id = object_id(N'Country') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Country

    if exists (select * from dbo.sysobjects where id = object_id(N'Semester') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Semester

    if exists (select * from dbo.sysobjects where id = object_id(N'ClassLevelSection') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ClassLevelSection

    if exists (select * from dbo.sysobjects where id = object_id(N'[User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [User]

    if exists (select * from dbo.sysobjects where id = object_id(N'Room') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Room

    if exists (select * from dbo.sysobjects where id = object_id(N'Teacher') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Teacher

    if exists (select * from dbo.sysobjects where id = object_id(N'CourseSection') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CourseSection

    if exists (select * from dbo.sysobjects where id = object_id(N'ClassroomStudent') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ClassroomStudent

    if exists (select * from dbo.sysobjects where id = object_id(N'Classroom') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Classroom

    if exists (select * from dbo.sysobjects where id = object_id(N'ClassroomTeacher') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ClassroomTeacher

    if exists (select * from dbo.sysobjects where id = object_id(N'CourseSectionStudent') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CourseSectionStudent

    if exists (select * from dbo.sysobjects where id = object_id(N'CourseSectionTeacher') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CourseSectionTeacher

    if exists (select * from dbo.sysobjects where id = object_id(N'PerformanceMeasurement') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PerformanceMeasurement

    if exists (select * from dbo.sysobjects where id = object_id(N'GradingSystem') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GradingSystem

    if exists (select * from dbo.sysobjects where id = object_id(N'DiscreteGrade') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table DiscreteGrade

    if exists (select * from dbo.sysobjects where id = object_id(N'Configuration') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Configuration

    if exists (select * from dbo.sysobjects where id = object_id(N'Student') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Student

    if exists (select * from dbo.sysobjects where id = object_id(N'CurriculumFramework') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CurriculumFramework

    if exists (select * from dbo.sysobjects where id = object_id(N'CurriculumCourse') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CurriculumCourse

    if exists (select * from dbo.sysobjects where id = object_id(N'UserRole') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table UserRole

    if exists (select * from dbo.sysobjects where id = object_id(N'Admission') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Admission

    if exists (select * from dbo.sysobjects where id = object_id(N'AdmissionTest') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AdmissionTest

    if exists (select * from dbo.sysobjects where id = object_id(N'TestScore') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TestScore

    if exists (select * from dbo.sysobjects where id = object_id(N'StudentApplication') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StudentApplication

    if exists (select * from dbo.sysobjects where id = object_id(N'AdmitCurriculum') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AdmitCurriculum

    if exists (select * from dbo.sysobjects where id = object_id(N'AlternateSchool') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AlternateSchool

    if exists (select * from dbo.sysobjects where id = object_id(N'Absence') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Absence

    if exists (select * from dbo.sysobjects where id = object_id(N'Punishment') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Punishment

    if exists (select * from dbo.sysobjects where id = object_id(N'Reward') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Reward

    if exists (select * from dbo.sysobjects where id = object_id(N'StudentSemester') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StudentSemester

    if exists (select * from dbo.sysobjects where id = object_id(N'StudentAcademicYear') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StudentAcademicYear

    if exists (select * from dbo.sysobjects where id = object_id(N'Photo') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Photo

    if exists (select * from dbo.sysobjects where id = object_id(N'RoyalDecoration') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table RoyalDecoration

    if exists (select * from dbo.sysobjects where id = object_id(N'Education') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Education

    if exists (select * from dbo.sysobjects where id = object_id(N'Experience') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Experience

    if exists (select * from dbo.sysobjects where id = object_id(N'AcademicAchievement') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AcademicAchievement

    if exists (select * from dbo.sysobjects where id = object_id(N'AcademicEventParticipation') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AcademicEventParticipation

    if exists (select * from dbo.sysobjects where id = object_id(N'Role') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Role

    if exists (select * from dbo.sysobjects where id = object_id(N'Application') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Application

    if exists (select * from dbo.sysobjects where id = object_id(N'AdmissionTestRoom') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AdmissionTestRoom

    if exists (select * from dbo.sysobjects where id = object_id(N'SchoolAdministrator') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SchoolAdministrator

    if exists (select * from dbo.sysobjects where id = object_id(N'Receipt') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Receipt

    if exists (select * from dbo.sysobjects where id = object_id(N'ReceiptItem') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ReceiptItem

    if exists (select * from dbo.sysobjects where id = object_id(N'ReceiptTemplate') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ReceiptTemplate

    if exists (select * from dbo.sysobjects where id = object_id(N'ReceiptTemplateItem') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ReceiptTemplateItem

    if exists (select * from dbo.sysobjects where id = object_id(N'ReceivableItem') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ReceivableItem

    if exists (select * from dbo.sysobjects where id = object_id(N'Register') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Register

    if exists (select * from dbo.sysobjects where id = object_id(N'RegisterDetail') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table RegisterDetail

    if exists (select * from dbo.sysobjects where id = object_id(N'RegisterPayment') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table RegisterPayment

    if exists (select * from dbo.sysobjects where id = object_id(N'Screen') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Screen

    if exists (select * from dbo.sysobjects where id = object_id(N'Module') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Module

    if exists (select * from dbo.sysobjects where id = object_id(N'CourseSectionPerformance') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CourseSectionPerformance

    if exists (select * from dbo.sysobjects where id = object_id(N'CourseSectionAppraisal') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CourseSectionAppraisal

    if exists (select * from dbo.sysobjects where id = object_id(N'ChartOfAccount') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ChartOfAccount

    if exists (select * from dbo.sysobjects where id = object_id(N'Organization') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Organization

    if exists (select * from dbo.sysobjects where id = object_id(N'Ledger') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Ledger

    if exists (select * from dbo.sysobjects where id = object_id(N'JournalEntry') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table JournalEntry

    if exists (select * from dbo.sysobjects where id = object_id(N'AccountingTransaction') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AccountingTransaction

    if exists (select * from dbo.sysobjects where id = object_id(N'AccountingPeriod') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AccountingPeriod

    if exists (select * from dbo.sysobjects where id = object_id(N'AuthorizeModule') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AuthorizeModule

    if exists (select * from dbo.sysobjects where id = object_id(N'AuthorizeScreen') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AuthorizeScreen

    if exists (select * from dbo.sysobjects where id = object_id(N'AutomaticGrading') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AutomaticGrading

    create table Language (
        LanguageCode NVARCHAR(255) not null,
       SeqNo INT null,
       ShortTitle NVARCHAR(255) null,
       SmallImageBytes VARBINARY(MAX) null,
       Title NVARCHAR(255) null,
       primary key (LanguageCode)
    )

    create table MLSValue (
        ID BIGINT IDENTITY NOT NULL,
       MLSID BIGINT null,
       LanguageCode NVARCHAR(255) null,
       Value NVARCHAR(255) null,
       primary key (ID)
    )

    create table MultilingualString (
        MLSID BIGINT IDENTITY NOT NULL,
       Code NVARCHAR(255) null,
       primary key (MLSID)
    )

    create table OrgName (
        ID BIGINT IDENTITY NOT NULL,
       OrganizationID INT null,
       TitleMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table PartyAddress (
        ID INT IDENTITY NOT NULL,
       CategoryID INT null,
       PartyDiscriminator TINYINT null,
       PartyID INT null,
       GeographicAddressID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table Password (
        ID BIGINT IDENTITY NOT NULL,
       UserID BIGINT null,
       EncryptedPassword NVARCHAR(255) null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       primary key (ID)
    )

    create table PersonName (
        ID BIGINT IDENTITY NOT NULL,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       PersonID INT null,
       FirstNameMLSID BIGINT null,
       LastNameMLSID BIGINT null,
       MiddleNameMLSID BIGINT null,
       PrefixMLSID BIGINT null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table Curriculum (
        ID BIGINT IDENTITY NOT NULL,
       CurriculumFrameworkID BIGINT null,
       SchoolID INT null,
       StartingClassLevelID BIGINT null,
       EndingClassLevelID BIGINT null,
       TitleMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table DesiredOutcome (
        ID BIGINT IDENTITY NOT NULL,
       Discriminator NVARCHAR(255) not null,
       Code NVARCHAR(255) null,
       TitleMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       CurriculumFrameworkID BIGINT null,
       ParentID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       DefaultGradingSystemID INT null,
       ClassLevelID BIGINT null,
       primary key (ID)
    )

    create table ClassLevel (
        ID BIGINT IDENTITY NOT NULL,
       CategoryID INT null,
       Code NVARCHAR(255) null,
       LevelNo INT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       ShortTitleMLSID BIGINT null,
       TitleMLSID BIGINT null,
       primary key (ID)
    )

    create table Course (
        ID BIGINT IDENTITY NOT NULL,
       Code NVARCHAR(255) null,
       CourseNoMLSID BIGINT null,
       DescriptionMLSID BIGINT null,
       TitleMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       ClassLevelID BIGINT null,
       GradingSystemID INT null,
       OutcomeCategoryID BIGINT null,
       SchoolID INT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       CreditHours REAL null,
       HoursPerSemester INT null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table PerformanceIndicator (
        ID BIGINT IDENTITY NOT NULL,
       DescriptionMLSID BIGINT null,
       ClassLevelID BIGINT null,
       ClassLevelOutcomeID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       SequenceNo INT null,
       Weight REAL null,
       primary key (ID)
    )

    create table GeographicAddress (
        ID BIGINT IDENTITY NOT NULL,
       AddressNoMLSID BIGINT null,
       Street1MLSID BIGINT null,
       Street2MLSID BIGINT null,
       ProvinceID BIGINT null,
       DistrictID BIGINT null,
       SubdistrictID BIGINT null,
       TownID BIGINT null,
       CountryID NVARCHAR(255) null,
       PostalCode NVARCHAR(255) null,
       primary key (ID)
    )

    create table GeographicRegion (
        ID BIGINT IDENTITY NOT NULL,
       Code NVARCHAR(255) null,
       CountryID NVARCHAR(255) null,
       ParentID BIGINT null,
       TitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       primary key (ID)
    )

    create table Person (
        ID INT IDENTITY NOT NULL,
       BirthDate DATETIME null,
       DeceasedDate DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       CurrentNameID BIGINT null,
       BloodGroupNodeID INT null,
       CitizenOfCountryID NVARCHAR(255) null,
       EmailAddress NVARCHAR(255) null,
       GenderID INT null,
       HomePhoneNo NVARCHAR(255) null,
       MobilePhoneNo NVARCHAR(255) null,
       OccupationID INT null,
       OfficialIDNo NVARCHAR(255) null,
       RaceID INT null,
       ReligionID INT null,
       primary key (ID)
    )

    create table HierarchicalCategory (
        ID INT IDENTITY NOT NULL,
       Code NVARCHAR(255) null,
       TitleMLSID BIGINT null,
       DescriptionMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       LevelNo INT null,
       SeqNo INT null,
       Weight REAL null,
       RootID INT null,
       ParentID INT null,
       primary key (ID)
    )

    create table PartyIdentity (
        ID INT IDENTITY NOT NULL,
       CategoryID INT null,
       PartyDiscriminator TINYINT null,
       PartyID INT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       IDNo NVARCHAR(255) null,
       IssuedBy INT null,
       primary key (ID)
    )

    create table Country (
        Alpha3Code NVARCHAR(255) not null,
       Code NVARCHAR(255) null,
       Alpha2Code NVARCHAR(255) null,
       TitleMLSID BIGINT null,
       primary key (Alpha3Code)
    )

    create table Semester (
        ID BIGINT IDENTITY NOT NULL,
       AcademicYear INT null,
       SemesterNo INT null,
       SchoolID INT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       ApplicationFrom DATETIME null,
       ApplicationTo DATETIME null,
       TeachingFrom DATETIME null,
       TeachingTo DATETIME null,
       FinalExamFrom DATETIME null,
       FinalExamTo DATETIME null,
       primary key (ID)
    )

    create table ClassLevelSection (
        ID BIGINT IDENTITY NOT NULL,
       ClassLevelID BIGINT null,
       SchoolID INT null,
       SemesterID BIGINT null,
       TitleMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table [User] (
        ID BIGINT IDENTITY NOT NULL,
       ApplicationID BIGINT null,
       OrganizationID INT null,
       PersonID INT null,
       CurrentPasswordID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       ConsecutiveFailedLoginCount INT null,
       LastLoginTimestamp DATETIME null,
       LoginName NVARCHAR(255) null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table Room (
        ID BIGINT IDENTITY NOT NULL,
       SchoolID INT null,
       BuildingTitleMLSID BIGINT null,
       RoomNo NVARCHAR(255) null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       primary key (ID)
    )

    create table Teacher (
        ID INT IDENTITY NOT NULL,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       IDNo NVARCHAR(255) null,
       CategoryID INT null,
       SchoolID INT null,
       PersonID INT null,
       StatusID INT null,
       StartAcademicYear INT null,
       StartSemesterID BIGINT null,
       StartSemesterNo INT null,
       primary key (ID)
    )

    create table CourseSection (
        ID INT IDENTITY NOT NULL,
       CourseID BIGINT null,
       SemesterID BIGINT null,
       ClassLevelSectionID BIGINT null,
       RoomID BIGINT null,
       SchoolID INT null,
       primary key (ID)
    )

    create table ClassroomStudent (
        ID BIGINT IDENTITY NOT NULL,
       ClassroomID BIGINT null,
       StudentID INT null,
       GPA REAL null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       primary key (ID)
    )

    create table Classroom (
        ID BIGINT IDENTITY NOT NULL,
       ClassLevelSectionID BIGINT null,
       RoomID BIGINT null,
       SchoolID INT null,
       SemesterID BIGINT null,
       primary key (ID)
    )

    create table ClassroomTeacher (
        ID BIGINT IDENTITY NOT NULL,
       CategoryID INT null,
       ClassroomID BIGINT null,
       TeacherID INT null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       primary key (ID)
    )

    create table CourseSectionStudent (
        ID BIGINT IDENTITY NOT NULL,
       CourseSectionID INT null,
       StudentID INT null,
       GradeID BIGINT null,
       AttendedHours INT null,
       GradePoint REAL null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table CourseSectionTeacher (
        ID BIGINT IDENTITY NOT NULL,
       CourseSectionID INT null,
       TeacherID INT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table PerformanceMeasurement (
        ID BIGINT IDENTITY NOT NULL,
       CourseSectionID INT null,
       PerformanceIndicatorID BIGINT null,
       SemesterID BIGINT null,
       StudentID INT null,
       Point REAL null,
       SequenceNo INT null,
       primary key (ID)
    )

    create table GradingSystem (
        ID INT IDENTITY NOT NULL,
       Discriminator TINYINT not null,
       Code NVARCHAR(255) null,
       TitleMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       MaxPoint REAL null,
       MinPoint REAL null,
       primary key (ID)
    )

    create table DiscreteGrade (
        ID BIGINT IDENTITY NOT NULL,
       Symbol NVARCHAR(255) null,
       Point REAL null,
       GradingSystemID INT null,
       primary key (ID)
    )

    create table Configuration (
        ID INT IDENTITY NOT NULL,
       SystemID INT null,
       AcademicLevelRootID INT null,
       BloodGroupRootID INT null,
       CourseCategoryRootID INT null,
       GenderRootID INT null,
       MajorRootID INT null,
       OccupationRootID INT null,
       RaceRootID INT null,
       ReligionRootID INT null,
       StudentStatusRootID INT null,
       SchoolPositionRootID INT null,
       SchoolSupervisorCategoryRootID INT null,
       CurriculumCourseCategoryRootID INT null,
       RoyalDecorationRootID INT null,
       GuardianCategoryID INT null,
       FatherCategoryID INT null,
       MotherCategoryID INT null,
       PersonPersonRelationshipCategoryRootID INT null,
       RelativeCategoryID INT null,
       EducationLevelRootID INT null,
       DefaultCountryCode NVARCHAR(255) null,
       DefaultDateCultureName NVARCHAR(255) null,
       DefaultDateFormat NVARCHAR(255) null,
       DefaultLanguageCode NVARCHAR(255) null,
       primary key (ID)
    )

    create table Student (
        ID INT IDENTITY NOT NULL,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       IDNo NVARCHAR(255) null,
       CategoryID INT null,
       SchoolID INT null,
       PersonID INT null,
       MajorID INT null,
       StatusID INT null,
       AdmittedClassLevelID BIGINT null,
       AdmittedAcademicYear INT null,
       StartSemesterID BIGINT null,
       AdmittedSemesterNo INT null,
       AdmittedGPA REAL null,
       CurrentGPA REAL null,
       primary key (ID)
    )

    create table CurriculumFramework (
        ID BIGINT IDENTITY NOT NULL,
       Code NVARCHAR(255) null,
       TitleMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       primary key (ID)
    )

    create table CurriculumCourse (
        ID BIGINT IDENTITY NOT NULL,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       CategoryID INT null,
       CourseID BIGINT null,
       CurriculumID BIGINT null,
       ForClassLevelID BIGINT null,
       ForSemesterNo INT null,
       primary key (ID)
    )

    create table UserRole (
        ID BIGINT IDENTITY NOT NULL,
       UserID BIGINT null,
       RoleID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table Admission (
        ID INT IDENTITY NOT NULL,
       SeqNo INT null,
       DescriptionMLSID BIGINT null,
       SemesterID BIGINT null,
       SchoolID INT null,
       ApplicationReceiptTemplateID BIGINT null,
       RegistrationReceiptTemplateID BIGINT null,
       ApplicationFormURL NVARCHAR(255) null,
       ApplyFrom DATETIME null,
       ApplyTo DATETIME null,
       primary key (ID)
    )

    create table AdmissionTest (
        ID BIGINT IDENTITY NOT NULL,
       AdmissionID INT null,
       SeqNo INT null,
       Description NVARCHAR(255) null,
       Title NVARCHAR(255) null,
       TestFrom DATETIME null,
       TestTo DATETIME null,
       primary key (ID)
    )

    create table TestScore (
        ID BIGINT IDENTITY NOT NULL,
       AdmissionTestID BIGINT null,
       Remark NVARCHAR(255) null,
       Score REAL null,
       StudentApplicationID BIGINT null,
       primary key (ID)
    )

    create table StudentApplication (
        ID BIGINT IDENTITY NOT NULL,
       AdmissionID INT null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       IDNo NVARCHAR(255) null,
       AppliedCurriculumID BIGINT null,
       AppliedDate DATETIME null,
       ApplicantID INT null,
       FatherID INT null,
       GuardianID INT null,
       MotherID INT null,
       LastSchoolID INT null,
       LastClassLevelID BIGINT null,
       GPA REAL null,
       ONETScore REAL null,
       IsAdmitted INT null,
       TotalTestScore REAL null,
       Rank INT null,
       AdmissionTestRoomID INT null,
       primary key (ID)
    )

    create table AdmitCurriculum (
        ID BIGINT IDENTITY NOT NULL,
       AdmissionID INT null,
       AdmittedClassLevelID BIGINT null,
       ApplicationFormURL NVARCHAR(255) null,
       Capacity INT null,
       CurriculumID BIGINT null,
       Description NVARCHAR(255) null,
       DrawingFrom DATETIME null,
       DrawingTo DATETIME null,
       ForLocalPeopleOnly BIT null,
       RegisterFrom DATETIME null,
       RegisterTo DATETIME null,
       TestFrom DATETIME null,
       TestTo DATETIME null,
       TestResultPublishedDate DATETIME null,
       Title NVARCHAR(255) null,
       primary key (ID)
    )

    create table AlternateSchool (
        ID BIGINT IDENTITY NOT NULL,
       Rank INT null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       StudentApplicationID BIGINT null,
       SchoolID INT null,
       primary key (ID)
    )

    create table Absence (
        ID BIGINT IDENTITY NOT NULL,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       AbsenceHours REAL null,
       Date DATETIME null,
       CategoryID INT null,
       StudentID INT null,
       CourseSectionID INT null,
       primary key (ID)
    )

    create table Punishment (
        ID BIGINT IDENTITY NOT NULL,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       Date DATETIME null,
       DeductedPoint INT null,
       WrongDoingCategoryID INT null,
       PunishmentCategoryID INT null,
       StudentID INT null,
       primary key (ID)
    )

    create table Reward (
        ID BIGINT IDENTITY NOT NULL,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       Date DATETIME null,
       Description NVARCHAR(255) null,
       CategoryID INT null,
       StudentID INT null,
       primary key (ID)
    )

    create table StudentSemester (
        ID BIGINT IDENTITY NOT NULL,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       GPA REAL null,
       BehavioralPoint INT null,
       DeductedPoint INT null,
       ClassLevelID BIGINT null,
       SemesterID BIGINT null,
       StudentID INT null,
       SchoolID INT null,
       primary key (ID)
    )

    create table StudentAcademicYear (
        ID BIGINT IDENTITY NOT NULL,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       GPA REAL null,
       BehavioralPoint INT null,
       DeductedPoint INT null,
       AcademicYear INT null,
       ClassLevelID BIGINT null,
       StudentID INT null,
       SchoolID INT null,
       primary key (ID)
    )

    create table Photo (
        ID BIGINT IDENTITY NOT NULL,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       Date DATETIME null,
       Image VARBINARY(MAX) null,
       PersonID INT null,
       primary key (ID)
    )

    create table RoyalDecoration (
        ID BIGINT IDENTITY NOT NULL,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       Date DATETIME null,
       RoyalDecorationCategoryID INT null,
       PersonID INT null,
       primary key (ID)
    )

    create table Education (
        ID BIGINT IDENTITY NOT NULL,
       StartDate DATETIME null,
       GraduatedDate DATETIME null,
       PersonID INT null,
       EducationLevelID INT null,
       AcademicInstituteName NVARCHAR(255) null,
       AcademicInstituteAddress NVARCHAR(255) null,
       DegreeTitle NVARCHAR(255) null,
       ShortDegreeTitle NVARCHAR(255) null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table Experience (
        ID BIGINT IDENTITY NOT NULL,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       PersonID INT null,
       OrganizationID INT null,
       OrganizationName NVARCHAR(255) null,
       OrganizationAddress NVARCHAR(255) null,
       JobDescription NVARCHAR(255) null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table AcademicAchievement (
        ID BIGINT IDENTITY NOT NULL,
       Date DATETIME null,
       PersonID INT null,
       PerformanceIndicatorID BIGINT null,
       Description NVARCHAR(255) null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table AcademicEventParticipation (
        ID BIGINT IDENTITY NOT NULL,
       StartDate DATETIME null,
       EndDate DATETIME null,
       PersonID INT null,
       AcademicEventCategoryID INT null,
       AcademicEventTitle NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       Venue NVARCHAR(255) null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table Role (
        ID BIGINT IDENTITY NOT NULL,
       Code NVARCHAR(255) null,
       ApplicationID BIGINT null,
       DescriptionMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       TitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table Application (
        ID BIGINT not null,
       Code NVARCHAR(255) null,
       TitleMLSID BIGINT null,
       ShortTitleMLSID BIGINT null,
       primary key (ID)
    )

    create table AdmissionTestRoom (
        ID INT IDENTITY NOT NULL,
       Capacity INT null,
       AdmissionTestRoomID BIGINT null,
       AdmissionID INT null,
       primary key (ID)
    )

    create table SchoolAdministrator (
        ID INT IDENTITY NOT NULL,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       CategoryID INT null,
       SchoolID INT null,
       PersonID INT null,
       StatusID INT null,
       primary key (ID)
    )

    create table Receipt (
        ID BIGINT IDENTITY NOT NULL,
       Date DATETIME null,
       ReceiptNo NVARCHAR(255) null,
       PayerName NVARCHAR(255) null,
       PayerAddress NVARCHAR(255) null,
       TotalAmount DECIMAL(19,5) null,
       SemesterID BIGINT null,
       SchoolID INT null,
       StudentID INT null,
       primary key (ID)
    )

    create table ReceiptItem (
        ID BIGINT IDENTITY NOT NULL,
       SeqNo INT null,
       Amount DECIMAL(19,5) null,
       AmountPerUnit DECIMAL(19,5) null,
       Units INT null,
       ReceiptID BIGINT null,
       ReceivableItemID BIGINT null,
       primary key (ID)
    )

    create table ReceiptTemplate (
        ID BIGINT IDENTITY NOT NULL,
       ReceiptNote NVARCHAR(255) null,
       TotalAmount DECIMAL(19,5) null,
       SchoolID INT null,
       primary key (ID)
    )

    create table ReceiptTemplateItem (
        ID BIGINT IDENTITY NOT NULL,
       SeqNo INT null,
       DefaultAmount DECIMAL(19,5) null,
       DefaultAmountPerUnit DECIMAL(19,5) null,
       DefaultUnits INT null,
       ReceiptTemplateID BIGINT null,
       ReceivableItemID BIGINT null,
       primary key (ID)
    )

    create table ReceivableItem (
        ID BIGINT IDENTITY NOT NULL,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       DefaultAmount DECIMAL(19,5) null,
       SeqNo INT null,
       SchoolID INT null,
       TitleMLSID BIGINT null,
       primary key (ID)
    )

    create table Register (
        RegisterID BIGINT IDENTITY NOT NULL,
       SemesterID BIGINT null,
       SchoolID INT null,
       UserID BIGINT null,
       Subject_Amount INT null,
       Create_Date DATETIME null,
       Update_Date DATETIME null,
       primary key (RegisterID)
    )

    create table RegisterDetail (
        RegisterDetailID BIGINT IDENTITY NOT NULL,
       Status NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       RegisterID BIGINT null,
       CurriculumID BIGINT null,
       StudentID INT null,
       TeacherID INT null,
       primary key (RegisterDetailID)
    )

    create table RegisterPayment (
        RegisterPaymentID BIGINT IDENTITY NOT NULL,
       RegisterDetailID BIGINT null,
       CourseID BIGINT null,
       UserID BIGINT null,
       Price FLOAT(53) null,
       Unit INT null,
       Create_Date DATETIME null,
       Update_Date DATETIME null,
       primary key (RegisterPaymentID)
    )

    create table Screen (
        ID BIGINT IDENTITY NOT NULL,
       ModuleID BIGINT null,
       TitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       NavigateUrl NVARCHAR(255) null,
       SeqNo INT null,
       ParentID BIGINT null,
       primary key (ID)
    )

    create table Module (
        ID BIGINT IDENTITY NOT NULL,
       TitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       NavigateUrl NVARCHAR(255) null,
       SeqNo INT null,
       ParentID BIGINT null,
       primary key (ID)
    )

    create table CourseSectionPerformance (
        ID BIGINT IDENTITY NOT NULL,
       AppraisalDate DATETIME null,
       CourseSectionAppraisalID INT null,
       CourseSectionStudentID BIGINT null,
       Score REAL null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table CourseSectionAppraisal (
        ID INT IDENTITY NOT NULL,
       CourseSectionID INT null,
       AppraisalDate DATETIME null,
       SeqNo INT null,
       PerfectScore REAL null,
       AverageScore REAL null,
       MaxScore REAL null,
       MinScore REAL null,
       DescriptionMLSID BIGINT null,
       TitleMLSID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       primary key (ID)
    )

    create table ChartOfAccount (
        ID INT IDENTITY NOT NULL,
       Discriminator TINYINT not null,
       Balance DECIMAL(19,5) null,
       Description NVARCHAR(255) null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       OrganizationID INT null,
       ParentCategoryID INT null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       RootCategoryID INT null,
       ShortTitleMLSID BIGINT null,
       TitleMLSID BIGINT null,
       CurrentPeriodID INT null,
       IncreaseBalanceBy INT null,
       MonthsPerPeriod INT null,
       primary key (ID)
    )

    create table Organization (
        ID INT IDENTITY NOT NULL,
       Discriminator TINYINT not null,
       FiscalYearEndDate DATETIME null,
       ChartOfAccountID INT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       CategoryID INT null,
       EmailAddress NVARCHAR(255) null,
       OfficialIDNo NVARCHAR(255) null,
       CurrentNameID BIGINT null,
       URL NVARCHAR(255) null,
       SupervisoryOrganizationID INT null,
       MaxClassLevelID BIGINT null,
       MinClassLevelID BIGINT null,
       primary key (ID)
    )

    create table Ledger (
        ID INT IDENTITY NOT NULL,
       Description NVARCHAR(255) null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       OrganizationID INT null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       ShortTitleMLSID BIGINT null,
       TitleMLSID BIGINT null,
       primary key (ID)
    )

    create table JournalEntry (
        ID BIGINT IDENTITY NOT NULL,
       Discriminator TINYINT not null,
       AccountID INT null,
       Amount DECIMAL(19,5) null,
       PeriodID INT null,
       PostedTS DATETIME null,
       SeqNo INT null,
       TransactionID BIGINT null,
       primary key (ID)
    )

    create table AccountingTransaction (
        ID BIGINT IDENTITY NOT NULL,
       Amount DECIMAL(19,5) null,
       BalanceType INT null,
       Description NVARCHAR(255) null,
       EnteredTS DATETIME null,
       EntryType INT null,
       GLDate DATETIME null,
       LedgerID INT null,
       PostedTS DATETIME null,
       TransactionDate DATETIME null,
       primary key (ID)
    )

    create table AccountingPeriod (
        ID INT IDENTITY NOT NULL,
       AccountID INT null,
       FiscalYear INT null,
       PeriodNo INT null,
       Balance DECIMAL(19,5) null,
       BeginningBalance DECIMAL(19,5) null,
       EndingBalance DECIMAL(19,5) null,
       BeginDate DATETIME null,
       EndDate DATETIME null,
       ClosedDate DATETIME null,
       primary key (ID)
    )

    create table AuthorizeModule (
        ID BIGINT IDENTITY NOT NULL,
       OrganizationID INT null,
       RoleID BIGINT null,
       ModuleID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table AuthorizeScreen (
        ID BIGINT IDENTITY NOT NULL,
       OrganizationID INT null,
       RoleID BIGINT null,
       ScreenID BIGINT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       Reference NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (ID)
    )

    create table AutomaticGrading (
        ID BIGINT IDENTITY NOT NULL,
       SchoolID INT null,
       DiscreteGradeID BIGINT null,
       Percentage INT null,
       EffectiveFrom DATETIME null,
       EffectiveTo DATETIME null,
       primary key (ID)
    )

    alter table MLSValue 
        add constraint FK9152187C7BD97B4A 
        foreign key (MLSID) 
        references MultilingualString

    alter table OrgName 
        add constraint FKDFD657FE8E6F4204 
        foreign key (OrganizationID) 
        references Organization

    alter table OrgName 
        add constraint FKDFD657FE575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table OrgName 
        add constraint FKDFD657FE5E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table PartyAddress 
        add constraint FK2D1DF239F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table PartyAddress 
        add constraint FK2D1DF239243269A7 
        foreign key (GeographicAddressID) 
        references GeographicAddress

    alter table PartyAddress 
        add constraint FK2D1DF239C610EAE0 
        foreign key (PartyID) 
        references Person

    alter table Password 
        add constraint FKF23822D2F218E371 
        foreign key (UserID) 
        references [User]

    alter table PersonName 
        add constraint FK19BD5E1B984D96D3 
        foreign key (PersonID) 
        references Person

    alter table PersonName 
        add constraint FK19BD5E1B2E90658D 
        foreign key (FirstNameMLSID) 
        references MultilingualString

    alter table PersonName 
        add constraint FK19BD5E1B1CC1051E 
        foreign key (LastNameMLSID) 
        references MultilingualString

    alter table PersonName 
        add constraint FK19BD5E1B1FD87135 
        foreign key (MiddleNameMLSID) 
        references MultilingualString

    alter table PersonName 
        add constraint FK19BD5E1BF55E95D 
        foreign key (PrefixMLSID) 
        references MultilingualString

    alter table Curriculum 
        add constraint FK4FB23EAAB0981DE 
        foreign key (CurriculumFrameworkID) 
        references CurriculumFramework

    alter table Curriculum 
        add constraint FK4FB23EAA673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Curriculum 
        add constraint FK4FB23EAA12A6D31A 
        foreign key (StartingClassLevelID) 
        references ClassLevel

    alter table Curriculum 
        add constraint FK4FB23EAA234B5126 
        foreign key (EndingClassLevelID) 
        references ClassLevel

    alter table Curriculum 
        add constraint FK4FB23EAA575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Curriculum 
        add constraint FK4FB23EAA5E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table DesiredOutcome 
        add constraint FK52CE2211575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table DesiredOutcome 
        add constraint FK52CE22115E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table DesiredOutcome 
        add constraint FK52CE2211B0981DE 
        foreign key (CurriculumFrameworkID) 
        references CurriculumFramework

    alter table DesiredOutcome 
        add constraint FK52CE2211696C8972 
        foreign key (ParentID) 
        references DesiredOutcome

    alter table DesiredOutcome 
        add constraint FK52CE2211FF5D6B2A 
        foreign key (DefaultGradingSystemID) 
        references GradingSystem

    alter table DesiredOutcome 
        add constraint FK52CE2211DF83CA9E 
        foreign key (ClassLevelID) 
        references ClassLevel

    alter table ClassLevel 
        add constraint FK74ACBA10F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table ClassLevel 
        add constraint FK74ACBA105E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table ClassLevel 
        add constraint FK74ACBA10575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Course 
        add constraint FKFFF43403C11127A8 
        foreign key (CourseNoMLSID) 
        references MultilingualString

    alter table Course 
        add constraint FKFFF43403345C57B0 
        foreign key (DescriptionMLSID) 
        references MultilingualString

    alter table Course 
        add constraint FKFFF43403575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Course 
        add constraint FKFFF434035E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table Course 
        add constraint FKFFF43403DF83CA9E 
        foreign key (ClassLevelID) 
        references ClassLevel

    alter table Course 
        add constraint FKFFF43403600E2A93 
        foreign key (GradingSystemID) 
        references GradingSystem

    alter table Course 
        add constraint FKFFF43403A685EF61 
        foreign key (OutcomeCategoryID) 
        references DesiredOutcome

    alter table Course 
        add constraint FKFFF43403673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table PerformanceIndicator 
        add constraint FK73C798CB345C57B0 
        foreign key (DescriptionMLSID) 
        references MultilingualString

    alter table PerformanceIndicator 
        add constraint FK73C798CBDF83CA9E 
        foreign key (ClassLevelID) 
        references ClassLevel

    alter table PerformanceIndicator 
        add constraint FK73C798CBC597107D 
        foreign key (ClassLevelOutcomeID) 
        references DesiredOutcome

    alter table GeographicAddress 
        add constraint FK9BDA06707B543F88 
        foreign key (AddressNoMLSID) 
        references MultilingualString

    alter table GeographicAddress 
        add constraint FK9BDA06702B441BF5 
        foreign key (Street1MLSID) 
        references MultilingualString

    alter table GeographicAddress 
        add constraint FK9BDA067054D213FE 
        foreign key (Street2MLSID) 
        references MultilingualString

    alter table GeographicAddress 
        add constraint FK9BDA06706A58440B 
        foreign key (ProvinceID) 
        references GeographicRegion

    alter table GeographicAddress 
        add constraint FK9BDA0670D92DBFB9 
        foreign key (DistrictID) 
        references GeographicRegion

    alter table GeographicAddress 
        add constraint FK9BDA0670CAD380C 
        foreign key (SubdistrictID) 
        references GeographicRegion

    alter table GeographicAddress 
        add constraint FK9BDA06706E7B1A37 
        foreign key (TownID) 
        references GeographicRegion

    alter table GeographicAddress 
        add constraint FK9BDA06701ABADAEC 
        foreign key (CountryID) 
        references Country

    alter table GeographicRegion 
        add constraint FK85167F821ABADAEC 
        foreign key (CountryID) 
        references Country

    alter table GeographicRegion 
        add constraint FK85167F828E14B6EA 
        foreign key (ParentID) 
        references GeographicRegion

    alter table GeographicRegion 
        add constraint FK85167F82575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Person 
        add constraint FK8C55D8ABA8D7C5AF 
        foreign key (CurrentNameID) 
        references PersonName

    alter table Person 
        add constraint FK8C55D8ABD6F2F02B 
        foreign key (BloodGroupNodeID) 
        references HierarchicalCategory

    alter table Person 
        add constraint FK8C55D8AB29DD5C57 
        foreign key (CitizenOfCountryID) 
        references Country

    alter table Person 
        add constraint FK8C55D8AB7A3270FF 
        foreign key (GenderID) 
        references HierarchicalCategory

    alter table Person 
        add constraint FK8C55D8AB62058B43 
        foreign key (OccupationID) 
        references HierarchicalCategory

    alter table Person 
        add constraint FK8C55D8AB9AB70F08 
        foreign key (RaceID) 
        references HierarchicalCategory

    alter table Person 
        add constraint FK8C55D8AB73F728E8 
        foreign key (ReligionID) 
        references HierarchicalCategory

    alter table HierarchicalCategory 
        add constraint FK35E813F575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table HierarchicalCategory 
        add constraint FK35E813F345C57B0 
        foreign key (DescriptionMLSID) 
        references MultilingualString

    alter table HierarchicalCategory 
        add constraint FK35E813F5E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table HierarchicalCategory 
        add constraint FK35E813F55DE22B4 
        foreign key (RootID) 
        references HierarchicalCategory

    alter table HierarchicalCategory 
        add constraint FK35E813F4A8C2AD3 
        foreign key (ParentID) 
        references HierarchicalCategory

    alter table PartyIdentity 
        add constraint FK331D9CC5F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table PartyIdentity 
        add constraint FK331D9CC56B1B0DAD 
        foreign key (IssuedBy) 
        references Organization

    alter table PartyIdentity 
        add constraint FK331D9CC5C610EAE0 
        foreign key (PartyID) 
        references Person

    alter table Country 
        add constraint FK2ABF29C3575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Semester 
        add constraint FK50043DF2673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table ClassLevelSection 
        add constraint FK9836A5BBDF83CA9E 
        foreign key (ClassLevelID) 
        references ClassLevel

    alter table ClassLevelSection 
        add constraint FK9836A5BB673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table ClassLevelSection 
        add constraint FK9836A5BBB06A8A23 
        foreign key (SemesterID) 
        references Semester

    alter table ClassLevelSection 
        add constraint FK9836A5BB575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table ClassLevelSection 
        add constraint FK9836A5BB5E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table [User] 
        add constraint FK67804DA4F3CC5328 
        foreign key (ApplicationID) 
        references Application

    alter table [User] 
        add constraint FK67804DA48E6F4204 
        foreign key (OrganizationID) 
        references Organization

    alter table [User] 
        add constraint FK67804DA4984D96D3 
        foreign key (PersonID) 
        references Person

    alter table [User] 
        add constraint FK67804DA4FAE3254F 
        foreign key (CurrentPasswordID) 
        references Password

    alter table Room 
        add constraint FKA43605DD673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Room 
        add constraint FKA43605DD55DE9358 
        foreign key (BuildingTitleMLSID) 
        references MultilingualString

    alter table Teacher 
        add constraint FK882079A7F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table Teacher 
        add constraint FK882079A7673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Teacher 
        add constraint FK882079A7984D96D3 
        foreign key (PersonID) 
        references Person

    alter table Teacher 
        add constraint FK882079A776E3D8D6 
        foreign key (StatusID) 
        references HierarchicalCategory

    alter table Teacher 
        add constraint FK882079A7786F1B8E 
        foreign key (StartSemesterID) 
        references Semester

    alter table CourseSection 
        add constraint FK55BC43D3495E2B7F 
        foreign key (CourseID) 
        references Course

    alter table CourseSection 
        add constraint FK55BC43D3B06A8A23 
        foreign key (SemesterID) 
        references Semester

    alter table CourseSection 
        add constraint FK55BC43D3BFF4F5D 
        foreign key (ClassLevelSectionID) 
        references ClassLevelSection

    alter table CourseSection 
        add constraint FK55BC43D3B7D0928F 
        foreign key (RoomID) 
        references Room

    alter table CourseSection 
        add constraint FK55BC43D3673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table ClassroomStudent 
        add constraint FK732A69A262192F31 
        foreign key (ClassroomID) 
        references Classroom

    alter table ClassroomStudent 
        add constraint FK732A69A2BF91423D 
        foreign key (StudentID) 
        references Student

    alter table Classroom 
        add constraint FKAC4A75BABFF4F5D 
        foreign key (ClassLevelSectionID) 
        references ClassLevelSection

    alter table Classroom 
        add constraint FKAC4A75BAB7D0928F 
        foreign key (RoomID) 
        references Room

    alter table Classroom 
        add constraint FKAC4A75BA673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Classroom 
        add constraint FKAC4A75BAB06A8A23 
        foreign key (SemesterID) 
        references Semester

    alter table ClassroomTeacher 
        add constraint FKDC8285D9F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table ClassroomTeacher 
        add constraint FKDC8285D962192F31 
        foreign key (ClassroomID) 
        references Classroom

    alter table ClassroomTeacher 
        add constraint FKDC8285D968C475E0 
        foreign key (TeacherID) 
        references Teacher

    alter table CourseSectionStudent 
        add constraint FKC2C0BEA7256CF10 
        foreign key (CourseSectionID) 
        references CourseSection

    alter table CourseSectionStudent 
        add constraint FKC2C0BEA7BF91423D 
        foreign key (StudentID) 
        references Student

    alter table CourseSectionStudent 
        add constraint FKC2C0BEA7F6BF02B1 
        foreign key (GradeID) 
        references DiscreteGrade

    alter table CourseSectionTeacher 
        add constraint FK7B762B8256CF10 
        foreign key (CourseSectionID) 
        references CourseSection

    alter table CourseSectionTeacher 
        add constraint FK7B762B868C475E0 
        foreign key (TeacherID) 
        references Teacher

    alter table PerformanceMeasurement 
        add constraint FK26516C66256CF10 
        foreign key (CourseSectionID) 
        references CourseSection

    alter table PerformanceMeasurement 
        add constraint FK26516C66E867AF38 
        foreign key (PerformanceIndicatorID) 
        references PerformanceIndicator

    alter table PerformanceMeasurement 
        add constraint FK26516C66B06A8A23 
        foreign key (SemesterID) 
        references Semester

    alter table PerformanceMeasurement 
        add constraint FK26516C66BF91423D 
        foreign key (StudentID) 
        references Student

    alter table GradingSystem 
        add constraint FK180A7094575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table GradingSystem 
        add constraint FK180A70945E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table DiscreteGrade 
        add constraint FK765D4B60CBB71C77 
        foreign key (GradingSystemID) 
        references GradingSystem

    alter table Student 
        add constraint FK5EE628FBF2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table Student 
        add constraint FK5EE628FB673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Student 
        add constraint FK5EE628FB984D96D3 
        foreign key (PersonID) 
        references Person

    alter table Student 
        add constraint FK5EE628FB25A7976B 
        foreign key (MajorID) 
        references HierarchicalCategory

    alter table Student 
        add constraint FK5EE628FB76E3D8D6 
        foreign key (StatusID) 
        references HierarchicalCategory

    alter table Student 
        add constraint FK5EE628FB848293A8 
        foreign key (AdmittedClassLevelID) 
        references ClassLevel

    alter table Student 
        add constraint FK5EE628FB786F1B8E 
        foreign key (StartSemesterID) 
        references Semester

    alter table CurriculumFramework 
        add constraint FKD5CC1243575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table CurriculumFramework 
        add constraint FKD5CC12435E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table CurriculumCourse 
        add constraint FKF47C10F5F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table CurriculumCourse 
        add constraint FKF47C10F5495E2B7F 
        foreign key (CourseID) 
        references Course

    alter table CurriculumCourse 
        add constraint FKF47C10F549E5D649 
        foreign key (CurriculumID) 
        references Curriculum

    alter table CurriculumCourse 
        add constraint FKF47C10F55BE10676 
        foreign key (ForClassLevelID) 
        references ClassLevel

    alter table UserRole 
        add constraint FK297C0BDEF218E371 
        foreign key (UserID) 
        references [User]

    alter table UserRole 
        add constraint FK297C0BDE7EBC4621 
        foreign key (RoleID) 
        references Role

    alter table Admission 
        add constraint FKADEBC81F345C57B0 
        foreign key (DescriptionMLSID) 
        references MultilingualString

    alter table Admission 
        add constraint FKADEBC81FB06A8A23 
        foreign key (SemesterID) 
        references Semester

    alter table Admission 
        add constraint FKADEBC81F673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Admission 
        add constraint FKADEBC81F8D31B83F 
        foreign key (ApplicationReceiptTemplateID) 
        references ReceiptTemplate

    alter table Admission 
        add constraint FKADEBC81F24EB43E5 
        foreign key (RegistrationReceiptTemplateID) 
        references ReceiptTemplate

    alter table AdmissionTest 
        add constraint FK38F9836B8A9FF62A 
        foreign key (AdmissionID) 
        references Admission

    alter table TestScore 
        add constraint FK26A94C9B6C1A03A7 
        foreign key (AdmissionTestID) 
        references AdmissionTest

    alter table TestScore 
        add constraint FK26A94C9BA80C643D 
        foreign key (StudentApplicationID) 
        references StudentApplication

    alter table StudentApplication 
        add constraint FK51C08A8E8A9FF62A 
        foreign key (AdmissionID) 
        references Admission

    alter table StudentApplication 
        add constraint FK51C08A8EF24A603B 
        foreign key (AppliedCurriculumID) 
        references AdmitCurriculum

    alter table StudentApplication 
        add constraint FK51C08A8E3393F897 
        foreign key (ApplicantID) 
        references Person

    alter table StudentApplication 
        add constraint FK51C08A8E5BBA57AD 
        foreign key (FatherID) 
        references Person

    alter table StudentApplication 
        add constraint FK51C08A8E8F0379E5 
        foreign key (GuardianID) 
        references Person

    alter table StudentApplication 
        add constraint FK51C08A8E5BF459FA 
        foreign key (MotherID) 
        references Person

    alter table StudentApplication 
        add constraint FK51C08A8EFE633CCD 
        foreign key (LastSchoolID) 
        references Organization

    alter table StudentApplication 
        add constraint FK51C08A8EA4F489C8 
        foreign key (LastClassLevelID) 
        references ClassLevel

    alter table StudentApplication 
        add constraint FK51C08A8E9050CA29 
        foreign key (AdmissionTestRoomID) 
        references AdmissionTestRoom

    alter table AdmitCurriculum 
        add constraint FK52C460318A9FF62A 
        foreign key (AdmissionID) 
        references Admission

    alter table AdmitCurriculum 
        add constraint FK52C46031848293A8 
        foreign key (AdmittedClassLevelID) 
        references ClassLevel

    alter table AdmitCurriculum 
        add constraint FK52C4603149E5D649 
        foreign key (CurriculumID) 
        references Curriculum

    alter table AlternateSchool 
        add constraint FK91319BFCA80C643D 
        foreign key (StudentApplicationID) 
        references StudentApplication

    alter table AlternateSchool 
        add constraint FK91319BFC673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Absence 
        add constraint FK513A3A7DF2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table Absence 
        add constraint FK513A3A7DBF91423D 
        foreign key (StudentID) 
        references Student

    alter table Absence 
        add constraint FK513A3A7D256CF10 
        foreign key (CourseSectionID) 
        references CourseSection

    alter table Punishment 
        add constraint FKC23A5F1CBFE8DFC 
        foreign key (WrongDoingCategoryID) 
        references HierarchicalCategory

    alter table Punishment 
        add constraint FKC23A5F1CB226B37B 
        foreign key (PunishmentCategoryID) 
        references HierarchicalCategory

    alter table Punishment 
        add constraint FKC23A5F1CBF91423D 
        foreign key (StudentID) 
        references Student

    alter table Reward 
        add constraint FK1A1B2009F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table Reward 
        add constraint FK1A1B2009BF91423D 
        foreign key (StudentID) 
        references Student

    alter table StudentSemester 
        add constraint FKA0E487B7DF83CA9E 
        foreign key (ClassLevelID) 
        references ClassLevel

    alter table StudentSemester 
        add constraint FKA0E487B7B06A8A23 
        foreign key (SemesterID) 
        references Semester

    alter table StudentSemester 
        add constraint FKA0E487B7BF91423D 
        foreign key (StudentID) 
        references Student

    alter table StudentSemester 
        add constraint FKA0E487B7673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table StudentAcademicYear 
        add constraint FK4E0D2B45DF83CA9E 
        foreign key (ClassLevelID) 
        references ClassLevel

    alter table StudentAcademicYear 
        add constraint FK4E0D2B45BF91423D 
        foreign key (StudentID) 
        references Student

    alter table StudentAcademicYear 
        add constraint FK4E0D2B45673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Photo 
        add constraint FK44C0C48A984D96D3 
        foreign key (PersonID) 
        references Person

    alter table RoyalDecoration 
        add constraint FKEDFA4DA862D9F043 
        foreign key (RoyalDecorationCategoryID) 
        references HierarchicalCategory

    alter table RoyalDecoration 
        add constraint FKEDFA4DA8984D96D3 
        foreign key (PersonID) 
        references Person

    alter table Education 
        add constraint FKA29C30D984D96D3 
        foreign key (PersonID) 
        references Person

    alter table Education 
        add constraint FKA29C30D255568BC 
        foreign key (EducationLevelID) 
        references HierarchicalCategory

    alter table Experience 
        add constraint FK85E4D6C3984D96D3 
        foreign key (PersonID) 
        references Person

    alter table Experience 
        add constraint FK85E4D6C38E6F4204 
        foreign key (OrganizationID) 
        references Organization

    alter table AcademicAchievement 
        add constraint FK3223B02F984D96D3 
        foreign key (PersonID) 
        references Person

    alter table AcademicAchievement 
        add constraint FK3223B02FE867AF38 
        foreign key (PerformanceIndicatorID) 
        references PerformanceIndicator

    alter table AcademicEventParticipation 
        add constraint FKF8A10617984D96D3 
        foreign key (PersonID) 
        references Person

    alter table AcademicEventParticipation 
        add constraint FKF8A106178354F09E 
        foreign key (AcademicEventCategoryID) 
        references HierarchicalCategory

    alter table Role 
        add constraint FK6117A80CF3CC5328 
        foreign key (ApplicationID) 
        references Application

    alter table Role 
        add constraint FK6117A80C345C57B0 
        foreign key (DescriptionMLSID) 
        references MultilingualString

    alter table Role 
        add constraint FK6117A80C5E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table Role 
        add constraint FK6117A80C575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Application 
        add constraint FK6AF3367D575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Application 
        add constraint FK6AF3367D5E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table AdmissionTestRoom 
        add constraint FKC8A5EA4DB9423D9 
        foreign key (AdmissionTestRoomID) 
        references Room

    alter table AdmissionTestRoom 
        add constraint FKC8A5EA4D8A9FF62A 
        foreign key (AdmissionID) 
        references Admission

    alter table SchoolAdministrator 
        add constraint FK9920B579F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table SchoolAdministrator 
        add constraint FK9920B579673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table SchoolAdministrator 
        add constraint FK9920B579984D96D3 
        foreign key (PersonID) 
        references Person

    alter table SchoolAdministrator 
        add constraint FK9920B57976E3D8D6 
        foreign key (StatusID) 
        references HierarchicalCategory

    alter table Receipt 
        add constraint FKEE2653A8B06A8A23 
        foreign key (SemesterID) 
        references Semester

    alter table Receipt 
        add constraint FKEE2653A8673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Receipt 
        add constraint FKEE2653A8BF91423D 
        foreign key (StudentID) 
        references Student

    alter table ReceiptItem 
        add constraint FKE86169E9930578D0 
        foreign key (ReceiptID) 
        references Receipt

    alter table ReceiptItem 
        add constraint FKE86169E937865257 
        foreign key (ReceivableItemID) 
        references ReceivableItem

    alter table ReceiptTemplate 
        add constraint FK686D76F4673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table ReceiptTemplateItem 
        add constraint FK57AFC1B7227CB706 
        foreign key (ReceiptTemplateID) 
        references ReceiptTemplate

    alter table ReceiptTemplateItem 
        add constraint FK57AFC1B737865257 
        foreign key (ReceivableItemID) 
        references ReceivableItem

    alter table ReceivableItem 
        add constraint FK1288F4B4673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table ReceivableItem 
        add constraint FK1288F4B4575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Register 
        add constraint FKEE955A37B06A8A23 
        foreign key (SemesterID) 
        references Semester

    alter table Register 
        add constraint FKEE955A37673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table Register 
        add constraint FKEE955A37F218E371 
        foreign key (UserID) 
        references [User]

    alter table RegisterDetail 
        add constraint FKB66FB4859DD9B2B 
        foreign key (RegisterID) 
        references Register

    alter table RegisterDetail 
        add constraint FKB66FB48549E5D649 
        foreign key (CurriculumID) 
        references Curriculum

    alter table RegisterDetail 
        add constraint FKB66FB485BF91423D 
        foreign key (StudentID) 
        references Student

    alter table RegisterDetail 
        add constraint FKB66FB48568C475E0 
        foreign key (TeacherID) 
        references Teacher

    alter table RegisterPayment 
        add constraint FK2C83F6B37EDD26E9 
        foreign key (RegisterDetailID) 
        references RegisterDetail

    alter table RegisterPayment 
        add constraint FK2C83F6B3495E2B7F 
        foreign key (CourseID) 
        references Course

    alter table RegisterPayment 
        add constraint FK2C83F6B3F218E371 
        foreign key (UserID) 
        references [User]

    alter table Screen 
        add constraint FKBEF9D81892B22A1F 
        foreign key (ModuleID) 
        references Module

    alter table Screen 
        add constraint FKBEF9D818575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Screen 
        add constraint FKBEF9D8189BE14FB9 
        foreign key (ParentID) 
        references Screen

    alter table Module 
        add constraint FKE5950A3B575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table Module 
        add constraint FKE5950A3BA0E84C0E 
        foreign key (ParentID) 
        references Module

    alter table CourseSectionPerformance 
        add constraint FKF16ED1EE50A49727 
        foreign key (CourseSectionAppraisalID) 
        references CourseSectionAppraisal

    alter table CourseSectionPerformance 
        add constraint FKF16ED1EE798D4E3D 
        foreign key (CourseSectionStudentID) 
        references CourseSectionStudent

    alter table CourseSectionAppraisal 
        add constraint FK712BFBFB256CF10 
        foreign key (CourseSectionID) 
        references CourseSection

    alter table CourseSectionAppraisal 
        add constraint FK712BFBFB345C57B0 
        foreign key (DescriptionMLSID) 
        references MultilingualString

    alter table CourseSectionAppraisal 
        add constraint FK712BFBFB575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table ChartOfAccount 
        add constraint FKCBFCF8D8E6F4204 
        foreign key (OrganizationID) 
        references Organization

    alter table ChartOfAccount 
        add constraint FKCBFCF8D1B3389C9 
        foreign key (ParentCategoryID) 
        references ChartOfAccount

    alter table ChartOfAccount 
        add constraint FKCBFCF8DFF2A98A3 
        foreign key (RootCategoryID) 
        references ChartOfAccount

    alter table ChartOfAccount 
        add constraint FKCBFCF8D5E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table ChartOfAccount 
        add constraint FKCBFCF8D575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table ChartOfAccount 
        add constraint FKCBFCF8DEA99F1CB 
        foreign key (CurrentPeriodID) 
        references AccountingPeriod

    alter table Organization 
        add constraint FKA7D893182A1FBAB9 
        foreign key (ChartOfAccountID) 
        references ChartOfAccount

    alter table Organization 
        add constraint FKA7D89318F2126A14 
        foreign key (CategoryID) 
        references HierarchicalCategory

    alter table Organization 
        add constraint FKA7D893187DFC9CCC 
        foreign key (CurrentNameID) 
        references OrgName

    alter table Organization 
        add constraint FKA7D89318DD469D20 
        foreign key (SupervisoryOrganizationID) 
        references HierarchicalCategory

    alter table Organization 
        add constraint FKA7D8931848CB873A 
        foreign key (MaxClassLevelID) 
        references ClassLevel

    alter table Organization 
        add constraint FKA7D8931895F30284 
        foreign key (MinClassLevelID) 
        references ClassLevel

    alter table Ledger 
        add constraint FK182C0A138E6F4204 
        foreign key (OrganizationID) 
        references Organization

    alter table Ledger 
        add constraint FK182C0A135E21BA14 
        foreign key (ShortTitleMLSID) 
        references MultilingualString

    alter table Ledger 
        add constraint FK182C0A13575208AB 
        foreign key (TitleMLSID) 
        references MultilingualString

    alter table JournalEntry 
        add constraint FK35C99074D98FC089 
        foreign key (AccountID) 
        references ChartOfAccount

    alter table JournalEntry 
        add constraint FK35C9907443EA2DCA 
        foreign key (PeriodID) 
        references AccountingPeriod

    alter table JournalEntry 
        add constraint FK35C99074A5695FA8 
        foreign key (TransactionID) 
        references AccountingTransaction

    alter table AccountingTransaction 
        add constraint FKE062BA8D5A650E7E 
        foreign key (LedgerID) 
        references Ledger

    alter table AccountingPeriod 
        add constraint FK11904ED8D98FC089 
        foreign key (AccountID) 
        references ChartOfAccount

    alter table AuthorizeModule 
        add constraint FK9196DB3D8E6F4204 
        foreign key (OrganizationID) 
        references Organization

    alter table AuthorizeModule 
        add constraint FK9196DB3D7EBC4621 
        foreign key (RoleID) 
        references Role

    alter table AuthorizeModule 
        add constraint FK9196DB3D92B22A1F 
        foreign key (ModuleID) 
        references Module

    alter table AuthorizeScreen 
        add constraint FK90D5D95A8E6F4204 
        foreign key (OrganizationID) 
        references Organization

    alter table AuthorizeScreen 
        add constraint FK90D5D95A7EBC4621 
        foreign key (RoleID) 
        references Role

    alter table AuthorizeScreen 
        add constraint FK90D5D95A9B354ECD 
        foreign key (ScreenID) 
        references Screen

    alter table AutomaticGrading 
        add constraint FKC0EDF055673FC9A1 
        foreign key (SchoolID) 
        references Organization

    alter table AutomaticGrading 
        add constraint FKC0EDF055669A7B88 
        foreign key (DiscreteGradeID) 
        references DiscreteGrade
