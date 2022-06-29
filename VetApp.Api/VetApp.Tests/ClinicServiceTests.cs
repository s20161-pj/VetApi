using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetApp.Model.Clinic;
using VetApp.Repository.Interfaces;
using VetApp.Services.Services;
using Xunit;

namespace VetApp.Tests
{
    public class ClinicServiceTests
    {
        [Fact]
        public async Task GetClinicById_ShouldReturnSuccessFalse_WhenClinicIsNotExist()
        {
            var sut = new ClinicService(Mock.Of<IMapper>(), Mock.Of<IClinicRepository>());
            var result = await sut.GetClinicById(1);
            
            result.Success.Should().BeFalse();
            result.Message.Should().Be("Brak podanej kliniki");
        }

        [Fact]
        public async Task GetClinicById_ShouldReturnSuccessTrue_WhenClinicIsExist()
        {
            var getClinicDto = new GetClinicDto
            {
                Name = "Klinika testowa",
                Address = "Gdynia",
                Id = 1, 
                Nip = "1111111"
            };

            var clinicRepositoryMock = new Moq.Mock<IClinicRepository>();
            clinicRepositoryMock.Setup(x => x.GetClinicByIdAsync(1)).ReturnsAsync(getClinicDto);
            var sut = new ClinicService(Mock.Of<IMapper>(), clinicRepositoryMock.Object);
            var result = await sut.GetClinicById(1);

            result.Success.Should().BeTrue();
            result.Message.Should().BeNull();
            result.Data.Name.Should().Be("Klinika testowa");
        }

        [Fact]
        public async Task GetAllClinics_ShouldReturnCollecionOfClinics()
        {
            var getClinicDtoList = new List<GetClinicDto> { 
                new GetClinicDto {
                    Name = "Klinika testowa",
                    Address = "Gdynia",
                    Id = 1,
                    Nip = "1111111"
                },
                new GetClinicDto {
                    Name = "Klinika testowa 2",
                    Address = "Gdañsk",
                    Id = 2,
                    Nip = "1111112"
                },
            };

            var clinicRepositoryMock = new Moq.Mock<IClinicRepository>();
            clinicRepositoryMock.Setup(x => x.GetAllClinicsAsync()).ReturnsAsync(getClinicDtoList);
            var sut = new ClinicService(Mock.Of<IMapper>(), clinicRepositoryMock.Object);
            var result = await sut.GetAllClinics();

            result.Success.Should().BeTrue();
            result.Message.Should().BeNull();
            result.Data.Count.Should().Be(getClinicDtoList.Count);
        }
    }
}